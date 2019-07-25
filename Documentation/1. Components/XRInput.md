### XRInput

![](../../Images/OculusControllersTouchControllers.jpg)

Reference: <https://docs.unity3d.com/Manual/OculusControllers.html>

#### Button

| Name                |
| ------------------- |
| One                 |
| Two                 |
| Three               |
| Four                |
| Start               |
| PrimaryThumbstick   |
| SecondaryThumbstick |

##### Get

```csharp
if (XRInput.Get(XRInput.Button.One)) {

    Debug.Log("Button One is being held");

}
```

##### GetDown

```csharp
if (XRInput.GetDown(XRInput.Button.One)) {

    Debug.Log("Button One was pressed");

}
```

##### GetUp

```csharp
if (XRInput.GetUp(XRInput.Button.One)) {

    Debug.Log("Button One was released");

}
```

#### Axis1D

| Name                  |
| --------------------- |
| PrimaryIndexTrigger   |
| SecondaryIndexTrigger |
| PrimaryHandTrigger    |
| SecondaryHandTrigger  |

##### Get

```csharp
if (XRInput.Get(XRInput.Axis1D.PrimaryIndexTrigger)) {

    Debug.Log("Primary Index Trigger is being held");

}
```

##### GetAxis

```csharp
Debug.Log($"Primary Index Trigger: {XRInput.GetAxis(XRInput.Axis1D.PrimaryIndexTrigger)}");
```

#### Axis2D

| Name                          |
| ----------------------------- |
| PrimaryThumbstickHorizontal   |
| PrimaryThumbstickVertical     |
| SecondaryThumbstickHorizontal |
| SecondaryThumbstickVertical   |

##### Get

```csharp
if (XRInput.Get(XRInput.Axis2D.PrimaryThumbstickHorizontal)) {

    Debug.Log("Primary Thumbstick Horizontal is being held to either the left or right");

}
```

##### GetAxis

```csharp
Debug.Log($"Primary Thumbstick Horizontal: {XRInput.GetAxis(XRInput.Axis2D.PrimaryThumbstickHorizontal)}");
```
