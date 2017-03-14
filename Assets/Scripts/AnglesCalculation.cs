using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;
using UnityEngine.UI;
using System;
using System.IO;

public class AnglesCalculation : MonoBehaviour
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
        try
        {
            byte[] angle = angles.GetVector(bodyframe.body);
        }
        catch (Exception ex)
        {
            Logger.Equals("Exception Log", ex);
        }
    }

    public class Angles
    {
        public Text txtRhandAngle;
        public Text txtLhandAngle;
        public Text txtResult;
        public InputField txtRAngle;
        public InputField txtLAngle;
        public Angles()
        {
            var rt = GameObject.Find("txtRhandAngle");
            var lt = GameObject.Find("txtLhandAngle");
            var result = GameObject.Find("txtResult");
            var rAngle = GameObject.Find("txtRAngle");
            var lAngle = GameObject.Find("txtLAngle");
            txtResult = result.GetComponent<Text>();
            txtRAngle = rAngle.GetComponent<InputField>();
           txtLAngle = lAngle.GetComponent<InputField>();
            txtRhandAngle = rt.GetComponent<Text>();
            txtLhandAngle = lt.GetComponent<Text>();
        }


        public double AngleBetweenTwoVectors(UnityEngine.Vector4 vectorA, UnityEngine.Vector4 vectorB)
        {
            double dotProduct;
            vectorA.Normalize();
            vectorB.Normalize();
            dotProduct = UnityEngine.Vector4.Dot(vectorA, vectorB);

            return (double)Math.Acos(dotProduct) / Math.PI * 180;
        }

        public byte[] GetVector(Body skeleton)
        {
            //Gathering Joints
            //Middle Joints
            UnityEngine.Vector4 Head = new UnityEngine.Vector4(skeleton.Joints[JointType.Head].Position.X, skeleton.Joints[JointType.Head].Position.Y, skeleton.Joints[JointType.Head].Position.Z);
            UnityEngine.Vector4 Neck = new UnityEngine.Vector4(skeleton.Joints[JointType.Neck].Position.X, skeleton.Joints[JointType.Neck].Position.Y, skeleton.Joints[JointType.Neck].Position.Z);
            UnityEngine.Vector4 SpineShoulder = new UnityEngine.Vector4(skeleton.Joints[JointType.SpineShoulder].Position.X, skeleton.Joints[JointType.SpineShoulder].Position.Y, skeleton.Joints[JointType.SpineShoulder].Position.Z);
            UnityEngine.Vector4 SpineMid = new UnityEngine.Vector4(skeleton.Joints[JointType.SpineMid].Position.X, skeleton.Joints[JointType.SpineMid].Position.Y, skeleton.Joints[JointType.SpineMid].Position.Z);
            UnityEngine.Vector4 SpineBase = new UnityEngine.Vector4(skeleton.Joints[JointType.SpineBase].Position.X, skeleton.Joints[JointType.SpineBase].Position.Y, skeleton.Joints[JointType.SpineBase].Position.Z);

            //Left Joints
            UnityEngine.Vector4 ShoulderLeft = new UnityEngine.Vector4(skeleton.Joints[JointType.ShoulderLeft].Position.X, skeleton.Joints[JointType.ShoulderLeft].Position.Y, skeleton.Joints[JointType.ShoulderLeft].Position.Z);
            UnityEngine.Vector4 ElbowLeft = new UnityEngine.Vector4(skeleton.Joints[JointType.ElbowLeft].Position.X, skeleton.Joints[JointType.ElbowLeft].Position.Y, skeleton.Joints[JointType.ElbowLeft].Position.Z);
            UnityEngine.Vector4 WristLeft = new UnityEngine.Vector4(skeleton.Joints[JointType.WristLeft].Position.X, skeleton.Joints[JointType.WristLeft].Position.Y, skeleton.Joints[JointType.WristLeft].Position.Z);
            UnityEngine.Vector4 HandLeft = new UnityEngine.Vector4(skeleton.Joints[JointType.HandLeft].Position.X, skeleton.Joints[JointType.HandLeft].Position.Y, skeleton.Joints[JointType.HandLeft].Position.Z);
            UnityEngine.Vector4 HipLeft = new UnityEngine.Vector4(skeleton.Joints[JointType.HipLeft].Position.X, skeleton.Joints[JointType.HipLeft].Position.Y, skeleton.Joints[JointType.HipLeft].Position.Z);
            UnityEngine.Vector4 KneeLeft = new UnityEngine.Vector4(skeleton.Joints[JointType.KneeLeft].Position.X, skeleton.Joints[JointType.KneeLeft].Position.Y, skeleton.Joints[JointType.KneeLeft].Position.Z);
            UnityEngine.Vector4 AnkleLeft = new UnityEngine.Vector4(skeleton.Joints[JointType.AnkleLeft].Position.X, skeleton.Joints[JointType.AnkleLeft].Position.Y, skeleton.Joints[JointType.AnkleLeft].Position.Z);
            UnityEngine.Vector4 FootLeft = new UnityEngine.Vector4(skeleton.Joints[JointType.FootLeft].Position.X, skeleton.Joints[JointType.FootLeft].Position.Y, skeleton.Joints[JointType.FootLeft].Position.Z);

            //Right Joints
            UnityEngine.Vector4 ShoulderRight = new UnityEngine.Vector4(skeleton.Joints[JointType.ShoulderRight].Position.X, skeleton.Joints[JointType.ShoulderRight].Position.Y, skeleton.Joints[JointType.ShoulderRight].Position.Z);
            UnityEngine.Vector4 ElbowRight = new UnityEngine.Vector4(skeleton.Joints[JointType.ElbowRight].Position.X, skeleton.Joints[JointType.ElbowRight].Position.Y, skeleton.Joints[JointType.ElbowRight].Position.Z);
            UnityEngine.Vector4 WristRight = new UnityEngine.Vector4(skeleton.Joints[JointType.WristRight].Position.X, skeleton.Joints[JointType.WristRight].Position.Y, skeleton.Joints[JointType.WristRight].Position.Z);
            UnityEngine.Vector4 HandRight = new UnityEngine.Vector4(skeleton.Joints[JointType.HandRight].Position.X, skeleton.Joints[JointType.HandRight].Position.Y, skeleton.Joints[JointType.HandRight].Position.Z);
            UnityEngine.Vector4 HipRight = new UnityEngine.Vector4(skeleton.Joints[JointType.HipRight].Position.X, skeleton.Joints[JointType.HipRight].Position.Y, skeleton.Joints[JointType.HipRight].Position.Z);
            UnityEngine.Vector4 KneeRight = new UnityEngine.Vector4(skeleton.Joints[JointType.KneeRight].Position.X, skeleton.Joints[JointType.KneeRight].Position.Y, skeleton.Joints[JointType.KneeRight].Position.Z);
            UnityEngine.Vector4 AnkleRight = new UnityEngine.Vector4(skeleton.Joints[JointType.AnkleRight].Position.X, skeleton.Joints[JointType.AnkleRight].Position.Y, skeleton.Joints[JointType.AnkleRight].Position.Z);
            UnityEngine.Vector4 FootRight = new UnityEngine.Vector4(skeleton.Joints[JointType.FootRight].Position.X, skeleton.Joints[JointType.FootRight].Position.Y, skeleton.Joints[JointType.FootRight].Position.Z);

            //Calculating Angles
            //Middle Angles 
            double NeckAngle = AngleBetweenTwoVectors(Neck - Head, Neck - SpineShoulder);
            double SpineAngle = AngleBetweenTwoVectors(SpineMid - SpineShoulder, SpineMid - SpineBase);

            //Left Angles 
            double NeckLeftAngle = AngleBetweenTwoVectors(SpineShoulder - Neck, SpineShoulder - ShoulderLeft);
            double ShoulderLeftAngle = AngleBetweenTwoVectors(ShoulderLeft - SpineShoulder, ShoulderLeft - ElbowLeft);
            double ElbowLeftAngle = AngleBetweenTwoVectors(ElbowLeft - ShoulderLeft, ElbowLeft - WristLeft);
            double WristLeftAngle = AngleBetweenTwoVectors(WristLeft - ElbowLeft, WristLeft - HandLeft);
            double HipLeftAngle = AngleBetweenTwoVectors(HipLeft - SpineMid, HipLeft - KneeLeft);
            double KneeLeftAngle = AngleBetweenTwoVectors(KneeLeft - HipLeft, KneeLeft - AnkleLeft);
            double AnkleLeftAngle = AngleBetweenTwoVectors(AnkleLeft - KneeLeft, AnkleLeft - FootLeft);


            //Right Angles 
            double NeckRightAngle = AngleBetweenTwoVectors(SpineShoulder - Neck, SpineShoulder - ShoulderRight);
            double ShoulderRightAngle = AngleBetweenTwoVectors(ShoulderRight - SpineShoulder, ShoulderRight - ElbowRight);
            double ElbowRightAngle = AngleBetweenTwoVectors(ElbowRight - ShoulderRight, ElbowRight - WristRight);
            double WristRightAngle = AngleBetweenTwoVectors(WristRight - ElbowRight, WristRight - HandRight);
            double HipRightAngle = AngleBetweenTwoVectors(HipRight - SpineMid, HipRight - KneeRight);
            double KneeRightAngle = AngleBetweenTwoVectors(KneeRight - HipRight, KneeRight - AnkleRight);
            double AnkleRightAngle = AngleBetweenTwoVectors(AnkleRight - KneeRight, AnkleRight - FootRight);

            byte[] Angles = {
                //NeckAngle Index : 0
                Convert.ToByte(NeckAngle),
                //SpineAngle Index : 1
                Convert.ToByte(SpineAngle),
                //NeckLeftAngle Index : 2
                Convert.ToByte(NeckLeftAngle),
                //ShoulderLeftAngle Index : 3
                Convert.ToByte(ShoulderLeftAngle),
                //ElbowLeftAngle Index : 4
                Convert.ToByte(ElbowLeftAngle),
                //WristLeftAngle Index : 5
                Convert.ToByte(WristLeftAngle),
                //HipLeftAngle Index : 6
                Convert.ToByte(HipLeftAngle),
                //KneeLeftAngle Index : 7
                Convert.ToByte(KneeLeftAngle),
                //AnkleLeftAngle Index : 8
                Convert.ToByte(AnkleLeftAngle),
                //NeckRightAngle Index : 9
                Convert.ToByte(NeckRightAngle),
                //ShoulderRightAngle Index : 10
                Convert.ToByte(ShoulderRightAngle),
                //ElbowRightAngle Index : 11
                Convert.ToByte(ElbowRightAngle),
                //WristRightAngle Index : 12
                Convert.ToByte(WristRightAngle),
                //HipRightAngle Index : 13
                Convert.ToByte(HipRightAngle),
                //KneeRightAngle Index : 14
                Convert.ToByte(KneeRightAngle),
                //AnkleRightAngle Index : 15
                Convert.ToByte(AnkleRightAngle)
            };

            var comparedLAngel = Convert.ToDouble(txtLAngle.text);
            var comparedRAngel = Convert.ToDouble(txtRAngle.text);
            txtLhandAngle.text = Angles[4].ToString();
            txtRhandAngle.text = Angles[11].ToString();
            UISampleWindow Pop = new UISampleWindow();
            
            //elbow comparison
            if (Convert.ToDouble(Angles[4]) <= (comparedLAngel + 5) && Convert.ToDouble(Angles[4]) >= (comparedLAngel - 5)
                &&
                Convert.ToDouble(Angles[11]) <= (comparedRAngel + 5) && Convert.ToDouble(Angles[11]) >= (comparedRAngel - 5))
            {
                Pop.DoneLevel();
            } else {
                txtResult.text = "Not Yet";
            }
            return Angles;
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
