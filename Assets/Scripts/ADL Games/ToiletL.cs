using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class ToiletL : MonoBehaviour
{
    KinBodyframe bodyframe;
    Angles angles;

    // Use this for initialization
    void Start()
    {
        bodyframe = new KinBodyframe();
        angles = new Angles();
    }

    // Update is called once per frame
    void Update()
    {
        angles.GetVector(bodyframe.body);
    }
    public class Angles
    {
        private bool lazyass = true;
        private bool IsDone = false;
        private bool IsStart = false;
        private int counter = 0;
        private Text txtRhandAngle;
        private Text txtLhandAngle;
        private Text txtResult;

        public Angles()
        {
            var rt = GameObject.Find("txtRhandAngle");
            var lt = GameObject.Find("txtLhandAngle");
            var result = GameObject.Find("txtResult");

            txtRhandAngle = rt.GetComponent<Text>();
            txtLhandAngle = lt.GetComponent<Text>();
            txtResult = result.GetComponent<Text>();
        }

        public void GetVector(Body skeleton)
        {
            //Gathering Joints
            //Middle Joints
            UnityEngine.Vector3 Head = new UnityEngine.Vector3(skeleton.Joints[JointType.Head].Position.X, skeleton.Joints[JointType.Head].Position.Y, skeleton.Joints[JointType.Head].Position.Z);
            UnityEngine.Vector3 Neck = new UnityEngine.Vector3(skeleton.Joints[JointType.Neck].Position.X, skeleton.Joints[JointType.Neck].Position.Y, skeleton.Joints[JointType.Neck].Position.Z);
            UnityEngine.Vector3 SpineShoulder = new UnityEngine.Vector3(skeleton.Joints[JointType.SpineShoulder].Position.X, skeleton.Joints[JointType.SpineShoulder].Position.Y, skeleton.Joints[JointType.SpineShoulder].Position.Z);
            UnityEngine.Vector3 SpineMid = new UnityEngine.Vector3(skeleton.Joints[JointType.SpineMid].Position.X, skeleton.Joints[JointType.SpineMid].Position.Y, skeleton.Joints[JointType.SpineMid].Position.Z);
            UnityEngine.Vector3 SpineBase = new UnityEngine.Vector3(skeleton.Joints[JointType.SpineBase].Position.X, skeleton.Joints[JointType.SpineBase].Position.Y, skeleton.Joints[JointType.SpineBase].Position.Z);

            //Left Joints
            UnityEngine.Vector3 ShoulderLeft = new UnityEngine.Vector3(skeleton.Joints[JointType.ShoulderLeft].Position.X, skeleton.Joints[JointType.ShoulderLeft].Position.Y, skeleton.Joints[JointType.ShoulderLeft].Position.Z);
            UnityEngine.Vector3 ElbowLeft = new UnityEngine.Vector3(skeleton.Joints[JointType.ElbowLeft].Position.X, skeleton.Joints[JointType.ElbowLeft].Position.Y, skeleton.Joints[JointType.ElbowLeft].Position.Z);
            UnityEngine.Vector3 WristLeft = new UnityEngine.Vector3(skeleton.Joints[JointType.WristLeft].Position.X, skeleton.Joints[JointType.WristLeft].Position.Y, skeleton.Joints[JointType.WristLeft].Position.Z);
            UnityEngine.Vector3 HandLeft = new UnityEngine.Vector3(skeleton.Joints[JointType.HandLeft].Position.X, skeleton.Joints[JointType.HandLeft].Position.Y, skeleton.Joints[JointType.HandLeft].Position.Z);
            UnityEngine.Vector3 HipLeft = new UnityEngine.Vector3(skeleton.Joints[JointType.HipLeft].Position.X, skeleton.Joints[JointType.HipLeft].Position.Y, skeleton.Joints[JointType.HipLeft].Position.Z);
            UnityEngine.Vector3 KneeLeft = new UnityEngine.Vector3(skeleton.Joints[JointType.KneeLeft].Position.X, skeleton.Joints[JointType.KneeLeft].Position.Y, skeleton.Joints[JointType.KneeLeft].Position.Z);
            UnityEngine.Vector3 AnkleLeft = new UnityEngine.Vector3(skeleton.Joints[JointType.AnkleLeft].Position.X, skeleton.Joints[JointType.AnkleLeft].Position.Y, skeleton.Joints[JointType.AnkleLeft].Position.Z);
            UnityEngine.Vector3 FootLeft = new UnityEngine.Vector3(skeleton.Joints[JointType.FootLeft].Position.X, skeleton.Joints[JointType.FootLeft].Position.Y, skeleton.Joints[JointType.FootLeft].Position.Z);

            //Right Joints
            UnityEngine.Vector3 ShoulderRight = new UnityEngine.Vector3(skeleton.Joints[JointType.ShoulderRight].Position.X, skeleton.Joints[JointType.ShoulderRight].Position.Y, skeleton.Joints[JointType.ShoulderRight].Position.Z);
            UnityEngine.Vector3 ElbowRight = new UnityEngine.Vector3(skeleton.Joints[JointType.ElbowRight].Position.X, skeleton.Joints[JointType.ElbowRight].Position.Y, skeleton.Joints[JointType.ElbowRight].Position.Z);
            UnityEngine.Vector3 WristRight = new UnityEngine.Vector3(skeleton.Joints[JointType.WristRight].Position.X, skeleton.Joints[JointType.WristRight].Position.Y, skeleton.Joints[JointType.WristRight].Position.Z);
            UnityEngine.Vector3 HandRight = new UnityEngine.Vector3(skeleton.Joints[JointType.HandRight].Position.X, skeleton.Joints[JointType.HandRight].Position.Y, skeleton.Joints[JointType.HandRight].Position.Z);
            UnityEngine.Vector3 HipRight = new UnityEngine.Vector3(skeleton.Joints[JointType.HipRight].Position.X, skeleton.Joints[JointType.HipRight].Position.Y, skeleton.Joints[JointType.HipRight].Position.Z);
            UnityEngine.Vector3 KneeRight = new UnityEngine.Vector3(skeleton.Joints[JointType.KneeRight].Position.X, skeleton.Joints[JointType.KneeRight].Position.Y, skeleton.Joints[JointType.KneeRight].Position.Z);
            UnityEngine.Vector3 AnkleRight = new UnityEngine.Vector3(skeleton.Joints[JointType.AnkleRight].Position.X, skeleton.Joints[JointType.AnkleRight].Position.Y, skeleton.Joints[JointType.AnkleRight].Position.Z);
            UnityEngine.Vector3 FootRight = new UnityEngine.Vector3(skeleton.Joints[JointType.FootRight].Position.X, skeleton.Joints[JointType.FootRight].Position.Y, skeleton.Joints[JointType.FootRight].Position.Z);

            movementChecker(WristLeft, SpineBase);
        }

        public bool closeChecker(UnityEngine.Vector3 joint1, UnityEngine.Vector3 joint2)
        {
            return Vector3.SqrMagnitude(joint1 - joint2) <= 0.08;
        }

        public bool farChecker(UnityEngine.Vector3 joint1, UnityEngine.Vector3 joint2)
        {
            return Vector3.SqrMagnitude(joint1 - joint2) >= 0.3;
        }

        public void movementChecker(UnityEngine.Vector3 joint1, UnityEngine.Vector3 joint2)
        {

            if (!IsStart)
            {
                if (closeChecker(joint1, joint2) && lazyass)
                {
                    counter++;
                    txtRhandAngle.text = counter.ToString();
                    lazyass = false;
                    if (counter == 10)
                    {
                        txtResult.text = "Complate";
                        IsStart = true;
                    }
                }
                else if (farChecker(joint1, joint2))
                    lazyass = true;
            }
            else
            {
                UISampleWindow Pop = new UISampleWindow();
                //TODO: Show Success
                Pop.DoneLevel();
            }
        }
    }

    public class KinBodyframe
    {
        // Active Kinect sensor
        private KinectSensor kinectSensor = null;

        // Reader for body frames
        private BodyFrameReader bodyFrameReader = null;

        // Array for the bodies
        private Body[] bodies = null;

        // index for the currently tracked body
        private int bodyIndex;

        // flag to asses if a body is currently tracked
        private bool bodyTracked = false;

        public Body body = null;

        public KinBodyframe()
        {
            this.kinectSensor = KinectSensor.GetDefault();

            // open the reader for the body frames
            this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();

            // open the sensor
            // this.kinectSensor.Open();

            this.bodyFrameReader.FrameArrived += this.Reader_FrameArrived;
        }

        // Handles the body frame data arriving from the sensor
        private void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;

            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (this.bodies == null)
                    {
                        this.bodies = new Body[bodyFrame.BodyCount];
                    }
                    bodyFrame.GetAndRefreshBodyData(this.bodies);
                    dataReceived = true;
                }
            }

            if (dataReceived)
            {
                body = null;
                if (this.bodyTracked)
                {
                    if (this.bodies[this.bodyIndex].IsTracked)
                    {
                        body = this.bodies[this.bodyIndex];
                    }
                    else
                    {
                        bodyTracked = false;
                    }
                }
                if (!bodyTracked)
                {
                    for (int i = 0; i < this.bodies.Length; ++i)
                    {
                        if (this.bodies[i].IsTracked)
                        {
                            this.bodyIndex = i;
                            this.bodyTracked = true;
                            break;
                        }
                    }
                }

                if (body != null && this.bodyTracked && body.IsTracked)
                {
                    // body represents your single tracked skeleton
                }
            }
        }
    }
}