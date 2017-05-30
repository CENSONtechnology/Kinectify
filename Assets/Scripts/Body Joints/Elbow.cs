using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class Elbow : MonoBehaviour
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
            byte[] a = angles.GetVector(bodyframe.body);
        }
        catch (Exception ex)
        {
            Logger.Equals("Exception Log", ex);

        }
    }
    public enum AngleType
    {
        NeckAngle,
        SpineAngle,
        NeckLeftAngle,
        ShoulderLeftAngle,
        ElbowLeftAngle,
        WristLeftAngle,
        HipLeftAngle,
        KneeLeftAngle,
        AnkleLeftAngle,
        NeckRightAngle,
        ShoulderRightAngle,
        ElbowRightAngle,
        WristRightAngle,
        HipRightAngle,
        KneeRightAngle,
        AnkleRightAngle
    }
    public class Angle
    {
        public double AngleValue { get; set; }
        public AngleType AngleT { get; set; }
        public bool Assigned { get; set; }
    }
    public class Angles
    {
        private Text txtRhandAngle;
        private UnityEngine.AudioSource lower;
        private UnityEngine.AudioSource raise;
        private UnityEngine.AudioSource open;
        private UnityEngine.AudioSource close;
        private static UnityEngine.AudioSource t_pose;
        private Text txtLhandAngle;
        private Text RightAngle;
        private Text LeftAngle;
        private Text txtCountR;
        private Text txtCountL;
        public bool UpperLBound { get; set; }
        public bool UpperRBound { get; set; }
        public int RightCounter { get; set; }
        public int LeftCounter { get; set; }
        private bool IsDone = false;
        private bool IsStart = false;
        // public InputField txtRAngle;
        // public InputField txtLAngle;


        public static List<Angle> AngleSet { get; set; }
        public Angles()
        {
                var rt = GameObject.Find("txtRhandAngle");
                var lt = GameObject.Find("txtLhandAngle");
            var result = GameObject.Find("txtResult");
            lower = GameObject.Find("lowerAudio").GetComponent<UnityEngine.AudioSource>();
            raise = GameObject.Find("raiseAudio").GetComponent<UnityEngine.AudioSource>();
            open = GameObject.Find("openAudio").GetComponent<UnityEngine.AudioSource>();
            close = GameObject.Find("closeAudio").GetComponent<UnityEngine.AudioSource>();
            t_pose = GameObject.Find("tpose").GetComponent<UnityEngine.AudioSource>();
            //var rAngle = GameObject.Find("txtRAngle");
            //var lAngle = GameObject.Find("txtLAngle");
            var countR = GameObject.Find("RightAngle");
            var countL = GameObject.Find("LeftAngle");

            // txtRAngle = rAngle.GetComponent<InputField>();
            // txtLAngle = lAngle.GetComponent<InputField>();
            txtRhandAngle = rt.GetComponent<Text>();
            txtLhandAngle = lt.GetComponent<Text>();
            txtCountR = countR.GetComponent<Text>();
            txtCountL = countL.GetComponent<Text>();
            AngleSet = new List<Angle>();
        }


        public double AngleBetweenTwoVectors(UnityEngine.Vector3 vectorA, UnityEngine.Vector3 vectorB)
        {
            double dotProduct;
            vectorA.Normalize();
            vectorB.Normalize();
            dotProduct = UnityEngine.Vector3.Dot(vectorA, vectorB);

            return (double)Math.Acos(dotProduct) / Math.PI * 180;
        }
        //public static void Start()
        //{
        //    t_pose = GameObject.Find("T-Pose").GetComponent<UnityEngine.AudioSource>();
        //    t_pose.Play();
        //}

        public byte[] GetVector(Body skeleton)
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

            Angle neckAngle = new Angle { AngleValue = NeckAngle, AngleT = AngleType.NeckAngle };
            Angle spineAngle = new Angle { AngleValue = SpineAngle, AngleT = AngleType.SpineAngle };
            Angle neckLeftAngle = new Angle { AngleValue = NeckLeftAngle, AngleT = AngleType.NeckLeftAngle };
            Angle shoulderLeftAngle = new Angle { AngleValue = ShoulderLeftAngle, AngleT = AngleType.ShoulderLeftAngle };
            Angle elbowLeftAngle = new Angle { AngleValue = ElbowLeftAngle, AngleT = AngleType.ElbowLeftAngle };
            Angle wristLeftAngle = new Angle { AngleValue = WristLeftAngle, AngleT = AngleType.WristLeftAngle };
            Angle hipLeftAngle = new Angle { AngleValue = HipLeftAngle, AngleT = AngleType.HipLeftAngle };
            Angle kneeLeftAngle = new Angle { AngleValue = KneeLeftAngle, AngleT = AngleType.KneeLeftAngle };
            Angle ankleLeftAngle = new Angle { AngleValue = AnkleLeftAngle, AngleT = AngleType.AnkleLeftAngle };
            Angle neckRightAngle = new Angle { AngleValue = NeckRightAngle, AngleT = AngleType.NeckRightAngle };
            Angle shoulderRightAngle = new Angle { AngleValue = ShoulderRightAngle, AngleT = AngleType.ShoulderRightAngle };
            Angle elbowRightAngle = new Angle { AngleValue = ElbowRightAngle, AngleT = AngleType.ElbowRightAngle };
            Angle wristRightAngle = new Angle { AngleValue = WristRightAngle, AngleT = AngleType.WristRightAngle };
            Angle hipRightAngle = new Angle { AngleValue = HipRightAngle, AngleT = AngleType.HipRightAngle };
            Angle kneeRightAngle = new Angle { AngleValue = KneeRightAngle, AngleT = AngleType.KneeRightAngle };
            Angle ankleRightAngle = new Angle { AngleValue = AnkleRightAngle, AngleT = AngleType.AnkleRightAngle };

            AngleSet.AddRange(new List<Angle> { neckAngle, spineAngle, neckLeftAngle, shoulderLeftAngle,
            elbowLeftAngle, wristLeftAngle, hipLeftAngle, kneeLeftAngle, ankleLeftAngle, neckRightAngle, shoulderRightAngle,
            elbowRightAngle, wristRightAngle, hipRightAngle, kneeRightAngle, ankleRightAngle});

            var comparedAngelMin = Convert.ToDouble(StartPlay.Right);
            var comparedAngelMax = Convert.ToDouble(StartPlay.Left);

            var toBeComparedL = AngleSet.Where(x => x.AngleT == AngleType.ElbowLeftAngle).FirstOrDefault().AngleValue;
            var toBeComparedR = AngleSet.Where(x => x.AngleT == AngleType.ElbowRightAngle).FirstOrDefault().AngleValue;


            if (!IsStart)
            {
                if (!(toBeComparedL <= 180 && toBeComparedL >= 160) && !(toBeComparedR <= 180 && toBeComparedR >= 160))
                {
                    t_pose.Play();
                }
                else
                    IsStart = true;
            }

            UISampleWindow Pop = new UISampleWindow();
            //elbow comparison
            if (!IsDone && IsStart)
            {
                if (!UpperLBound && (toBeComparedL <= comparedAngelMax + 7 && toBeComparedL >= comparedAngelMax - 7))
                {
                    UpperLBound = !UpperLBound;
                    close.Play();
                }
                if (UpperLBound && (toBeComparedL <= comparedAngelMin + 7 && toBeComparedL >= comparedAngelMin - 7))
                {
                    LeftCounter++;
                    UpperLBound = !UpperLBound;
                    txtLhandAngle.text = LeftCounter.ToString();
                    open.Play();
                }
                if (!UpperRBound && (toBeComparedR <= comparedAngelMax + 7 && toBeComparedR >= comparedAngelMax - 7))
                {
                    UpperRBound = !UpperRBound;
                    close.Play();
                }
                if (UpperRBound && (toBeComparedR <= comparedAngelMin + 7 && toBeComparedR >= comparedAngelMin - 7))
                {
                    RightCounter++;
                    UpperRBound = !UpperRBound;
                    open.Play();
                    txtRhandAngle.text = RightCounter.ToString();
                }
            }
            if (RightCounter >= 3 && LeftCounter >= 3 && !IsDone)
            {
                IsDone = true;
                Pop.DoneLevel();
                //TODO: Show Success
            }
            AngleSet.Clear();
            return new byte[1];
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