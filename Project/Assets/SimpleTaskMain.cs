using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SimpleTaskMain : MonoBehaviour
{
    async void Start()
    {
        Task<int> task = Task.Run<int>(new Func<int>(sluggishCalculate));
        //ラムダ式でもOK
        // Task<int> task = Task.Run<int>(() => {
        //     int retval=0;
        //     for(int i=0; i<100; i++)
        //     {
        //         retval+=i;
        //     }
        //     Thread.Sleep(5000);//重たい処理
        //     return retval;
        // });
        int result = await task;
        Debug.Log(result);
    }

    private int sluggishCalculate()
    {
        int retval=0;
        for(int i=0; i<100; i++)
        {
            retval+=i;
        }
        Thread.Sleep(5000);//重たい処理
        return retval;
    }
}
