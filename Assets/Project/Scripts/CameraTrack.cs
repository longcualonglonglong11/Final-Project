using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityChan{
    public class CameraTrack : MonoBehaviour
    {
        
        public float smooth = 100.0f;
        Transform standardPos, frontPos, jumpPos;
        bool quick = false;

        void Start()
        {
            standardPos = GameObject.Find("CamPos").transform;
            frontPos = GameObject.Find ("FrontPos").transform;
            jumpPos = GameObject.Find ("JumpPos").transform;

            transform.position = standardPos.position;	
			transform.forward = standardPos.forward;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Alpha1))
                setCameraPositionFrontView();
            else if (Input.GetKey(KeyCode.Alpha2))
                setCameraPositionJumpView();
            else setCameraPositionNormalView();
        }

        void setCameraPositionNormalView ()
		{
			if (quick == false) {
				// the camera to standard position and direction
				transform.position = Vector3.Lerp (transform.position, standardPos.position, Time.fixedDeltaTime * smooth);	
				transform.forward = Vector3.Lerp (transform.forward, standardPos.forward, Time.fixedDeltaTime * smooth);
			} else {
				// the camera to standard position and direction / Quick Change
				transform.position = standardPos.position;	
				transform.forward = standardPos.forward;
				quick = false;
			}
		}
	
		void setCameraPositionFrontView ()
		{
			// Change Front Camera
			quick = true;
			transform.position = frontPos.position;	
			transform.forward = frontPos.forward;
		}

		void setCameraPositionJumpView ()
		{
			// Change Jump Camera
			quick = false;
			transform.position = Vector3.Lerp (transform.position, jumpPos.position, Time.fixedDeltaTime * smooth);	
			transform.forward = Vector3.Lerp (transform.forward, jumpPos.forward, Time.fixedDeltaTime * smooth);		
		}
    }
}
