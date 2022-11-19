﻿using System.Collections.Generic;
using UnityEngine;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public static class ShuffleExtension {

        public static void Shuffle<T> (this T[] array, int shuffleAccuracy = 10) {
            for (int i = 0; i < shuffleAccuracy; i++) {
                int randomIndex = Random.Range (1, array.Length) ;

                T temp = array [ randomIndex ] ;
                array [ randomIndex ] = array [ 0 ] ;
                array[0] = temp;
            }
        }

        public static void Shuffle<T>(this List<T> list, int shuffleAccuracy = 10)
        {
            for (int i = 0; i < shuffleAccuracy; i++)
            {
                int randomIndex = Random.Range(1, list.Count);

                T temp = list[randomIndex];
                list[randomIndex] = list[0];
                list[0] = temp;
            }
        }
    }
}