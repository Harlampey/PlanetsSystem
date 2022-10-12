using System.Collections;
using UnityEngine;
using System;

[Serializable]
public class MassClassEnum : IEnumerator
{
    [SerializeField]

    public MassClassValues[] MassClasses;
    private int position = -1;
    object IEnumerator.Current { get { return Current; } }

    public MassClassEnum(MassClassValues[] list)
    {
        MassClasses = list;
    }
    public MassClassEnum()
    {

    }
    public MassClassValues Current
    {
        get
        {
            try
            {
                return MassClasses[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
    public bool MoveNext()
    {
        position++;
        return (position < MassClasses.Length);
    }

    public void Reset()
    {
        position = -1;
    }
}
