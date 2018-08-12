using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StableMarriageProblem
{
    public static class StableMarriage
    {
        public static int NO = 0;
        public static int MAY_BE = 1;
        public static int YES = 2;

        public static Pair[] Get(Human[] womenPreferences, Human[] menPreferences)
        {
            if (womenPreferences.Length != menPreferences.Length)
            {
                return null;
            }

            int quantity = menPreferences.Length;
            int iteration = 0;
            bool[] isWomenFree = new bool[quantity];
            for (int i = 0; i < isWomenFree.Length; i++)
            {
                isWomenFree[i] = true;
            }

            Pair[] stablePairs = new Pair[quantity];
            for (int i = 0; i < stablePairs.Length; i++)
            {
                stablePairs[i] = new Pair(i + 1, 0, NO); //создаем пары (заполняем только М + ответ НЕТ)
            }
            IEnumerator<int> enumerator;

            while (iteration < quantity)
            {
                for (int i = 0; i < stablePairs.Length; i++)
                {
                    if (stablePairs.All(pair => pair.Response != NO))
                    {
                        return stablePairs;
                    }

                    if (stablePairs[i].Response != NO)
                    {
                        continue;
                    }

                    int currentMan = i + 1;

                    enumerator = menPreferences[i].GetEnumerator();
                    
                    int currentWoman = enumerator.MoveNext() ? (int)enumerator.Current : 0; //в матрице предпочтений М берем i М и его предпочтения

                    bool isWomanFree = isWomenFree[currentWoman - 1];

                    if (isWomanFree)
                    {
                        stablePairs[i].Man = currentMan;
                        stablePairs[i].Woman = currentWoman;
                        stablePairs[i].Response =
                            currentMan == womenPreferences[currentWoman - 1].Preferences.First()
                            ? YES
                            : MAY_BE;
                        isWomenFree[currentWoman - 1] = false;
                    }
                    else //сравниваем с текущим М у несвободной Ж
                    {
                        Pair pairWithCurrentWoman = stablePairs.First(p => p.Woman == currentWoman);

                        for (int j = 0; j < womenPreferences[currentWoman - 1].Preferences.Length; j++)
                        {
                            if (womenPreferences[currentWoman - 1].Preferences[j] == pairWithCurrentWoman.Man)
                            {
                                break;
                            }

                            if (womenPreferences[currentWoman - 1].Preferences[j] == currentMan)
                            {
                                pairWithCurrentWoman.Woman = 0; //обнуляем пару с текущей Ж
                                pairWithCurrentWoman.Response = NO;

                                stablePairs[i].Man = currentMan; //освободившейся Ж текущий М делает предложение
                                if (stablePairs[i].Woman != 0)
                                {
                                    isWomenFree[stablePairs[i].Woman - 1] = true;
                                }
                                stablePairs[i].Woman = currentWoman;
                                stablePairs[i].Response =
                                    currentMan == womenPreferences[i].Preferences.First()
                                    ? YES
                                    : MAY_BE;

                                break;
                            }
                        }
                    }
                }

                iteration++;
            }

            return stablePairs;
        }

        //public static Pair[] Get(Human[] womenPreferences, Human[] menPreferences)
        //{
        //    if (womenPreferences.Length != menPreferences.Length)
        //    {
        //        return null;
        //    }

        //    int quantity = menPreferences.Length;
        //    int iteration = 0;
        //    bool[] isWomenFree = new bool[quantity];
        //    for (int i = 0; i < isWomenFree.Length; i++)
        //    {
        //        isWomenFree[i] = true;
        //    }

        //    Pair[] stablePairs = new Pair[quantity];
        //    for (int i = 0; i < stablePairs.Length; i++)
        //    {
        //        stablePairs[i] = new Pair(i + 1, 0, NO); //создаем пары (заполняем только М + ответ НЕТ)
        //    }

        //    while (iteration < quantity)
        //    {
        //        for (int i = 0; i < stablePairs.Length; i++)
        //        {
        //            if (stablePairs.All(pair => pair.Response != NO))
        //            {
        //                return stablePairs;
        //            }

        //            int currentMan = i + 1;
        //            int currentWoman = menPreferences[i].Preferences[iteration]; //в матрице предпочтений М берем i М и его предпочтения
        //            bool isWomanFree = isWomenFree[currentWoman - 1];

        //            if (isWomanFree)
        //            {
        //                stablePairs[i].Man = currentMan;
        //                stablePairs[i].Woman = currentWoman;
        //                stablePairs[i].Response =
        //                    currentMan == womenPreferences[currentWoman - 1].Preferences.First()
        //                    ? YES
        //                    : MAY_BE;
        //                isWomenFree[currentWoman - 1] = false;
        //            }
        //            else //сравниваем с текущим М у несвободной Ж
        //            {
        //                Pair pairWithCurrentWoman = stablePairs.First(p => p.Woman == currentWoman);

        //                for (int j = 0; j < womenPreferences[currentWoman - 1].Preferences.Length; j++)
        //                {
        //                    if (womenPreferences[currentWoman - 1].Preferences[j] == pairWithCurrentWoman.Man)
        //                    {
        //                        break;
        //                    }

        //                    if (womenPreferences[currentWoman - 1].Preferences[j] == currentMan)
        //                    {
        //                        pairWithCurrentWoman.Woman = 0; //обнуляем пару с текущей Ж
        //                        pairWithCurrentWoman.Response = NO;

        //                        stablePairs[i].Man = currentMan; //освободившейся Ж текущий М делает предложение
        //                        if (stablePairs[i].Woman != 0)
        //                        {
        //                            isWomenFree[stablePairs[i].Woman - 1] = true;
        //                        }
        //                        stablePairs[i].Woman = currentWoman;
        //                        stablePairs[i].Response =
        //                            currentMan == womenPreferences[i].Preferences.First()
        //                            ? YES
        //                            : MAY_BE;

        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        iteration++;
        //    }

        //    return stablePairs;
        //}

    }


}
