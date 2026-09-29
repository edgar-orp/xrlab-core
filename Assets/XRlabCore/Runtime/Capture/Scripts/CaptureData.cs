using UnityEngine;

namespace xrlab.core.capture
{
    public class CaptureData : MonoBehaviour
    {
        public Texture2D CapturedImage { get; private set; }

        public void SetImage(Texture2D image)
        {
            CapturedImage = image;
        }
    }
}
