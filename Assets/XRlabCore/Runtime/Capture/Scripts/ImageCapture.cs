using UnityEngine;

namespace xrlab.core.capture
{
    public class ImageCapture : MonoBehaviour
    {
        [SerializeField] private WebcamCapture webcamCapture;
        [SerializeField] private CaptureData captureData;

        public void Capture()
        {
            if (webcamCapture == null)
            {
                Debug.LogWarning("WebcamCapture reference is missing.");
                return;
            }

            if (captureData == null)
            {
                Debug.LogWarning("CaptureData reference is missing.");
                return;
            }

            WebCamTexture webcamTexture = webcamCapture.Texture;

            if (webcamTexture == null || !webcamTexture.isPlaying)
            {
                Debug.LogWarning("Webcam is not running.");
                return;
            }

            Texture2D capturedImage = new Texture2D(
                webcamTexture.width,
                webcamTexture.height,
                TextureFormat.RGBA32,
                false);

            capturedImage.SetPixels(webcamTexture.GetPixels());
            capturedImage.Apply();

            captureData.SetImage(capturedImage);

            webcamCapture.StopCamera();
        }
    }
}
