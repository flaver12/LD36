using UnityEngine;
using System.Collections;

public class RenderSettings : MonoBehaviour {

	[Range(0,10)]
	public int DownRes;
	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture rt = RenderTexture.GetTemporary(source.width >> DownRes, source.height >> DownRes);
		Graphics.Blit(source, rt);
		rt.filterMode = FilterMode.Point;
		rt.antiAliasing = 1;
		Graphics.Blit(rt, destination);
		RenderTexture.ReleaseTemporary(rt);
	}
}