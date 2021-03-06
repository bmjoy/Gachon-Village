﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Newtonsoft.Json.Linq;
public class FileItem : MonoBehaviour {
    public int no;
    public String owner;
    public UILabel UI_title;
    public UILabel UI_size;
    public UILabel UI_date;
    void OnClick()
    {
        // 우클릭이면
        if (UICamera.currentTouchID == -2)
        {
            FileMenu file = Preset.objects.fileMenu;
            file.no = this.no;
            Vector3 p2 = Input.mousePosition;
            p2.x = (int)p2.x;
            p2.y = (int)(-Screen.height + p2.y);
            file.transform.localPosition = p2;
            file.title.text = "From " + owner;
            file.gameObject.SetActive(true);
        }
    }
    void OnDoubleClick()
    {
        if (Preset.objects.PostWindow.isOpen())
        {
           Preset.objects.PostWindow.InputItem(no, UI_title.text);
        }
        else if (Preset.objects.StudyWindow.isOpen())
        {
            // 스터디에 파일 업로드
            JObject json = new JObject();
            json["type"] = NetworkProtocol.Study_FileUpload;
            json["group_name"] = Preset.objects.StudyWindow.key;
            json["no"] = no;
            NetworkMain.SendMessage(json);
        }
    }
}
