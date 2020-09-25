using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IUI
{
    Task Show();
    Task Hide();
}