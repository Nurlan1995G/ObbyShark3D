using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsBusy { get; private set; }

    public bool SetBusyTrue() => IsBusy = true;
    public bool SetBusyFalse() => IsBusy = false;
}
