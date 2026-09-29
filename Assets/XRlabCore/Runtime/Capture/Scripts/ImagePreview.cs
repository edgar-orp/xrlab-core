using UnityEngine;
using UnityEngine.UI;
using xrlab.core.capture;

namespace xrlab.core.UI
{
    public class ImagePreview : MonoBehaviour
    {
        [SerializeField] private CaptureData captureData;
        [SerializeField] private RawImage preview;
        [SerializeField] private AspectRatioFitter aspectRatioFitter;

        private void OnEnable()
        {
            ShowImage();
        }

        private void ShowImage()
        {
            if (captureData == null)
            {
                Debug.LogWarning("CaptureData reference is missing.");
                return;
            }

            if (preview == null)
            {
                Debug.LogWarning("Preview reference is missing.");
                return;
            }

            if (aspectRatioFitter == null)
            {
                Debug.LogWarning("AspectRatioFitter reference is missing.");
                return;
            }

            Texture2D capturedImage = captureData.CapturedImage;

            if (capturedImage == null)
            {
                Debug.LogWarning("Captured image is missing.");
                return;
            }

            preview.texture = capturedImage;

            UpdateAspectRatio(capturedImage);
        }

        private void UpdateAspectRatio(Texture2D image)
        {
            aspectRatioFitter.aspectRatio =
            (float)image.width / image.height;
        }
    }
}
