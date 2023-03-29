using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityInputSource 
{ 
    float HorizontalDirection { get; }
    bool Jump { get; }

}
