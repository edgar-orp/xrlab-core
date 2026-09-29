using UnityEngine;
using UnityEngine.UI;

namespace xrlab.core.capture
{
    public class WebcamCapture : MonoBehaviour
    {
        [SerializeField] private RawImage preview;
        [SerializeField] private AspectRatioFitter aspectRatioFitter;

        private string a;

        private WebCamTexture webcamTexture;

        public WebCamTexture Texture => webcamTexture;

        private void OnEnable()
        {
            StartCamera();
        }

        private void Update()
        {
            if (webcamTexture == null || !webcamTexture.isPlaying)
                return;

            if (webcamTexture.width <= 16)
                return;

            UpdateAspectRatio();
        }

        private void OnDestroy()
        {
            StopCamera();
        }

        public void StartCamera()
        {
            if (WebCamTexture.devices.Length == 0)
            {
                Debug.LogWarning("No webcam found.");
                return;
            }

            webcamTexture = new WebCamTexture(WebCamTexture.devices[0].name);

            preview.texture = webcamTexture;
            webcamTexture.Play();
        }

        public void StopCamera()
        {
            if (webcamTexture == null)
                return;

            webcamTexture.Stop();
        }

        private void UpdateAspectRatio()
        {
            aspectRatioFitter.aspectRatio =
                (float)webcamTexture.width / webcamTexture.height;
        }
    }
}
