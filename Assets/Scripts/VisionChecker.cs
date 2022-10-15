using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionChecker : MonoBehaviour
{
    private VisionEmitter[] visions;
    private ActionableByVision[] actions;

    /*private Vector3[] entityBounds = new Vector3[] {
        new Vector3( 0f,  0f,  0f),
        new Vector3(-1f, -1f, -1f),
        new Vector3(-1f, -1f,  1f),
        new Vector3(-1f,  1f, -1f),
        new Vector3(-1f,  1f,  1f),
        new Vector3( 1f, -1f, -1f),
        new Vector3( 1f, -1f,  1f),
        new Vector3( 1f,  1f, -1f),
        new Vector3( 1f,  1f,  1f)
    };*/

    bool CheckIfVisibleByEmitter(ActionableByVision action, VisionEmitter vision)
    {
        Camera visionCamera = vision.attachedCamera;
        //1. check if in frustrum
        bool inFrustrum;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(visionCamera);
        Collider objCollider = action.attachedCollider;

        inFrustrum = GeometryUtility.TestPlanesAABB(planes, objCollider.bounds);

        if (!inFrustrum)
        {
            return false;
        }

        //2. and check if not behind other objects
        Vector3[] entityVertices = action.attachedMeshFilter.mesh.vertices;

        // Raycast for each vertex of the mesh. The mesh must be within the collider.
        for (int i = 0, length = entityVertices.Length; i < length; i++)
        {
            Vector3 vertexWorld = action.transform.TransformPoint(entityVertices[i]);
            Vector3 rayDirection = vertexWorld - visionCamera.transform.position;

            Debug.DrawRay(visionCamera.transform.position, rayDirection, Color.red, 0.1f);
            RaycastHit hit;
            if (Physics.Raycast(visionCamera.transform.position, rayDirection, out hit))
            {
                // if the ray hit another object that is actionable and do not block the vision, 
                // then we re-raycast behind it to find the object
                ActionableByVision hitActionable = hit.collider.GetComponent<ActionableByVision>();
                while (hitActionable != null && !hitActionable.blocksVision && hit.collider.gameObject != action.gameObject)
                {
                    Debug.DrawRay(hit.point, rayDirection, Color.green, 0.1f);
                    if (!Physics.Raycast(hit.point + rayDirection.normalized * 0.01f, rayDirection, out hit))
                    {
                        break;
                    }
                    hitActionable = hit.collider.GetComponent<ActionableByVision>();
                }
                if (hit.collider != null && hit.collider.gameObject == action.gameObject)
                {
                    return true;
                }
            }
        }
        return false;
    }

    //Returns true if the object is visible by a vision emitter
    bool CheckIfVisible(ActionableByVision action)
    {
        foreach (VisionEmitter vision in visions)
        {
            if (CheckIfVisibleByEmitter(action, vision)) {
                return true;
            }
        }
        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateVisionsAndActions();
    }

    void UpdateVisionsAndActions()
    {
        visions = FindObjectsOfType<VisionEmitter>();
        actions = FindObjectsOfType<ActionableByVision>();
    }

    // Update is called once per frame
    // Maybe check less often then once per frame
    void Update()
    {
        foreach (ActionableByVision action in actions)
        {
            if (CheckIfVisible(action))
            {
                action.Activate();
            }
            else
            {
                action.Deactivate();
            }
        }
    }
}
