using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCamera : MonoBehaviour /*:OVRCameraRig*/
{
	public OVRCameraRig MainCamera;

    private PhotonView MyPhotonView;

	private void Start()
	{
		MyPhotonView = GetComponent<PhotonView>();
	}
	void Update()
    {
		if (MyPhotonView.IsMine) 
		{
			MainCamera.disableEyeAnchorCameras = false;
			if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight)) 
			{
				MainCamera.transform.eulerAngles = MainCamera.transform.eulerAngles + new Vector3(0, 0.1f, 0);
			}
			if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
			{
				MainCamera.transform.eulerAngles = MainCamera.transform.eulerAngles + new Vector3(0, -0.1f, 0);
			}
			
		}
    }
	//protected override void UpdateAnchors(bool updateEyeAnchors, bool updateHandAnchors)
	//{
	//	if (MyPhotonView.IsMine)
	//	{
	//		base.UpdateAnchors(updateEyeAnchors, updateHandAnchors);
	//	}
	//}
}
