using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodyView : MonoBehaviour
{
    public BodySourceManager bdsm;
    public GameObject JointObject;

    private Dictionary<ulong, GameObject> Bodies = new Dictionary<ulong, GameObject>();
    private List<JointType> joints = new List<JointType>
    {
        JointType.HandLeft,
        JointType.HandRight,
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Kinect Data
        Body[] data = bdsm.GetData();
        if (data == null)
            return;
        List<ulong> trackIds = new List<ulong>();
        foreach(var body in data)
        {
            if (body == null)
                continue;
            if (body.IsTracked)
                trackIds.Add(body.TrackingId);
        }
        #endregion
        #region DeleteKinecBodies
        List<ulong> knownIds = new List<ulong>(Bodies.Keys);
        foreach(ulong trackingId in knownIds)
        {
            if (!trackIds.Contains(trackingId))
            {
                Destroy(Bodies[trackingId]);

                Bodies.Remove(trackingId);
            }
        }
        #endregion
        #region CreateKinectBodies
        foreach(var body in data)
        {
            if (body == null)
                continue;
            if (body.IsTracked)
            {
                if (!Bodies.ContainsKey(body.TrackingId))
                    Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);

                UpdateBodyObject(body, Bodies[body.TrackingId]);
            }
        }

        #endregion

    }
    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = new GameObject("Body:" + id);
        foreach(JointType joint in joints)
        {
            GameObject newJoint = Instantiate(JointObject);
            newJoint.name = joints.ToString();

            newJoint.transform.parent = body.transform;
        }
        return body;
    }
    private void UpdateBodyObject(Body body,GameObject bodyObject)
    {
        foreach(JointType joint in joints)
        {
            Joint sourceJoint = body.Joints[joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;

            Transform jointObject = bodyObject.transform.Find(joint.ToString());
            jointObject.position = targetPosition;
        }
    }
    private Vector3 GetVector3FromJoint(Joint joints)
    {
        return new Vector3(joints.Position.X * 10, joints.Position.Y * 10, joints.Position.Z * 10);
    }
}
