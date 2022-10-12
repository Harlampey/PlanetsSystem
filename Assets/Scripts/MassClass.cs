using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class MassClass : IEnumerable
{
    [SerializeField]
    private MassClassValues[] _massClassValues; 

    public MassClass(MassClassValues[] pArray)
    {
        _massClassValues = pArray;
    }
    public IEnumerator GetEnumerator()
    {
        return new MassClassEnum(_massClassValues);
    }
}
