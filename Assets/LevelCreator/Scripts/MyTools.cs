using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyTools {
    public static List<T> GetListFromEnum<T>() {
        var result = new List<T>();
        Array enums = Enum.GetValues(typeof(T));
        foreach (T e in enums) {
            result.Add(e);
        }
        return result;
    }

    public static string GetSerializeJson(SaveItem saveItem) => JsonConvert.SerializeObject(saveItem);

    public static T DeserializeObject<T>(string s) => JsonConvert.DeserializeObject<T>(s);
}
