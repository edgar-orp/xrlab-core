using UnityEngine;

namespace XRlab.Core.Capture
{
    public class ImageCapture : MonoBehaviour
    {
        [SerializeField] private WebcamCapture webcamCapture;

        private Texture2D capturedImage;

        public Texture2D CapturedImage => capturedImage;

        public void Capture()
        {
            if (webcamCapture == null)
            {
                Debug.LogWarning("WebcamCapture reference is missing.");
                return;
            }

            WebCamTexture webcamTexture = webcamCapture.Texture;

            if (webcamTexture == null || !webcamTexture.isPlaying)
            {
                Debug.LogWarning("Webcam is not running.");
                return;
            }

            capturedImage = new Texture2D(
                webcamTexture.width,
                webcamTexture.height,
                TextureFormat.RGBA32,
                false);

            capturedImage.SetPixels(webcamTexture.GetPixels());
            capturedImage.Apply();
        }
    }
}