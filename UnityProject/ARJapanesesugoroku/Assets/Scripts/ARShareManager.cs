using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;
using Photon.Pun;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class ARShareManager : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;

    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    ARRaycastManager raycastManager;

    [SerializeField] private ARSession m_ARSession;
    [SerializeField] private Text outPutText;

    [SerializeField] private Text outPutText2;
    
    // Start is called before the first frame update
    void Start()
    {
//        byte[] testBytes = new byte[4];
//        testBytes[0] = 4;
//        testBytes[1] = 0;
//        testBytes[2] = 0;
//        testBytes[3] = 1;
        
//        StartCoroutine(Upload(testBytes, path => {
//            Debug.Log(path);
//        }));
        
//        StartCoroutine(Download("/files/ec950127679b0b7bd0bd0ee4abae1b2d5fc709182fa15fb24b9ca00efe609794", LoadSerializedWorldMap));

        //StartCoroutine(GetDataTest());
        //StartCoroutine(WWWTest());
        
        raycastManager = GetComponent<ARRaycastManager>();


    }

    // Update is called once per frame
    void Update()
    {
        outPutText2.text = PhotonNetwork.PlayerList.Length.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("raycastManager : " + raycastManager);
            Debug.Log("object : " + objectPrefab);
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults))
            {
                Debug.Log("Making obj...    ");
                Instantiate(objectPrefab, hitResults[0].pose.position, Quaternion.identity);
                Debug.Log("Made obj!");
            }
        }
    }

    public void ShareWorldMap()
    {
        StartCoroutine(ShareWorldMapCoroutine());
    }

    IEnumerator ShareWorldMapCoroutine()
    {
        ARKitSessionSubsystem sessionSubsystem = (ARKitSessionSubsystem) m_ARSession.subsystem;
        
        ARWorldMapRequest request = sessionSubsystem.GetARWorldMapAsync();

        outPutText.text = "Making WorldMap...";

        while (request.status == ARWorldMapRequestStatus.Pending)
        {
            outPutText.text = "Status : " + request.status;
            yield return null;
        }

        outPutText.text = "Finish request Status : " + request.status;
        
        // World Map を取得
        ARWorldMap worldMap = request.GetWorldMap();
        var data = worldMap.Serialize(Allocator.Temp);

        outPutText.text = "WorldMap Length : " + data.Length;
        Debug.Log(data.Length);

        //GetComponent<PhotonView>().RPC("RPCSetWorldMap", RpcTarget.All, data.ToArray());
        StartCoroutine(Upload(data.ToArray(), path => {
            GetComponent<PhotonView>().RPC("DownloadWorldMap", RpcTarget.AllBuffered, path);
        }));
        
        Debug.Log(data.Length);
        Debug.Log("Sent worldmap");
        data.Dispose();
        worldMap.Dispose();
    }
    
    [PunRPC]
    public void DownloadWorldMap(string path)
    {
        Debug.Log("Download World map");
        StartCoroutine(Download(path, LoadSerializedWorldMap));
    }

    [PunRPC]
    void RPCDebug()
    {
        Debug.Log("ok");
    }

    [PunRPC]
    void RPCSetWorldMap(byte[] worldmap)
    {
        outPutText.text = "SetWorldMap Length : " + worldmap.Length;
        NativeArray<byte> worldmap_native = new NativeArray<byte>(worldmap.Length, Allocator.Temp);
        Debug.Log(worldmap.Length);
        Debug.Log("native worldmap length: " + worldmap_native.Length);
        worldmap_native.CopyFrom(worldmap);
        ARWorldMap out_worldmap;
        outPutText.text = "Deserializing worldMap";

        if (ARWorldMap.TryDeserialize(worldmap_native, out out_worldmap))
        worldmap_native.Dispose();
            
            if (out_worldmap.valid)
            {
                outPutText.text = "Deserialized successfully."; 
                Debug.Log("Deserialized successfully.");
            }
            else
            {
                outPutText.text = "Data is not a valid ARWorldMap.";
                Debug.LogError("Data is not a valid ARWorldMap.");
            }

        Debug.Log("Apply ARWorldMap to current session.");
        ARKitSessionSubsystem arKitSessionSubsystem = (ARKitSessionSubsystem) m_ARSession.subsystem;
        arKitSessionSubsystem.ApplyWorldMap(out_worldmap);
        outPutText.text = "Complete";
    }

    IEnumerator WWWTest()
    {
        byte[] testBytes = new byte[4];
        testBytes[0] = 4;
        testBytes[1] = 0;
        testBytes[2] = 0;
        testBytes[3] = 1;
        
        UnityWebRequest wr = new UnityWebRequest("https://invited-crowd.glitch.me/upload", "POST");
        UploadHandler uploadHandler = new UploadHandlerRaw(testBytes);
        wr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
//        uploadHandler.contentType = "custom/content-type";

        wr.uploadHandler = uploadHandler;

        yield return wr.SendWebRequest();
        Debug.Log(wr.downloadHandler.text);
    }

    IEnumerator GetDataTest()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://invited-crowd.glitch.me/public/files/bc32c07274439f3026e994897eb04b559e5617051ceb7239d46e1ab4f438b558");
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        
        www.SendWebRequest();

        while (!www.isDone)
        {
            Debug.Log(www.downloadProgress);
            yield return null;
        }

        File.WriteAllBytes(Application.persistentDataPath + "/temp2.bin", www.downloadHandler.data);
        Debug.Log(www.downloadHandler.data.Length);
        
        Debug.Log(www.error);
        Debug.Log("done.");
    }
    
    static Uri BASE = new Uri("https://invited-crowd.glitch.me");
    
    public IEnumerator Upload(byte[] worldMapData, Action<string> callback)
    {
    	var request = new UnityWebRequest(new Uri(BASE, "upload").ToString());
    	request.method = "POST";
    	request.SetRequestHeader("Content-Type", "application/octet-stream");
    	request.uploadHandler = new UploadHandlerRaw(worldMapData);
    	var downloadhandler = new DownloadHandlerBuffer();
        request.downloadHandler = downloadhandler;
    	yield return request.SendWebRequest();
    	callback.Invoke(downloadhandler.text);
    	yield return downloadhandler.text;
    }
    
    public IEnumerator Download(string path, Action<byte[]> callback)
    {
    	var request = new UnityWebRequest(new Uri(BASE, path).ToString());
    	var downloadhandler = new DownloadHandlerBuffer();
        request.downloadHandler = downloadhandler;
    	yield return request.SendWebRequest();
    	callback.Invoke(downloadhandler.data);
    	yield return downloadhandler.data;
    }

    void LoadSerializedWorldMap(byte[] worldmap)
    {
        Debug.Log(worldmap.Length);
        outPutText.text = "SetWorldMap Length : " + worldmap.Length;
        NativeArray<byte> worldmap_native = new NativeArray<byte>(worldmap.Length, Allocator.Temp);
        Debug.Log(worldmap.Length);
        Debug.Log("native worldmap length: " + worldmap_native.Length);
        worldmap_native.CopyFrom(worldmap);
        ARWorldMap out_worldmap;
        outPutText.text = "Deserializing worldMap";

        if (ARWorldMap.TryDeserialize(worldmap_native, out out_worldmap))
        worldmap_native.Dispose();
            
            if (out_worldmap.valid)
            {
                outPutText.text = "Deserialized successfully."; 
                Debug.Log("Deserialized successfully.");
            }
            else
            {
                outPutText.text = "Data is not a valid ARWorldMap.";
                Debug.LogError("Data is not a valid ARWorldMap.");
            }

        Debug.Log("Apply ARWorldMap to current session.");
        ARKitSessionSubsystem arKitSessionSubsystem = (ARKitSessionSubsystem) m_ARSession.subsystem;
        arKitSessionSubsystem.ApplyWorldMap(out_worldmap);
        outPutText.text = "Complete";
    }
}
