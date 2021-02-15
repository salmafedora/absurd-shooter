using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public interface IFactory
    {
        GameObject FactoryMethod(int tag);
    }
}