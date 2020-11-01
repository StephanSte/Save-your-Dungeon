using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    //In the OnSceneGUI you can do for example mesh editing, terrain painting or advanced gizmos
    [System.Obsolete]
    void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        //GetInfoString center, direction of rotation, start of angle, dedgrees, actual radius 
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
        
        //kein plan was das macht war bei einer lösung dabei
        //fov.viewAngle = (int)Handles.ScaleValueHandle(fov.viewAngle, fov.transform.position + (fov.transform.forward * fov.viewAngle), fov.transform.rotation, 1, Handles.ConeCap, 1);

        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }
    }
}