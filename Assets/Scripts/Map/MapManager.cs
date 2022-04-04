using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{
	public const float maxViewDst = 80;
	public Transform viewer;
	public GameObject Maps;
	public static Vector2 viewerPosition;
	int chunkSize = 100;
	int chunksVisibleInViewDst;

	public Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
	public List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();
	public static MapManager instance = null;

	private void Awake()
	{
		instance = this;
	}
	void Start()
	{
		chunksVisibleInViewDst = Mathf.RoundToInt(maxViewDst / chunkSize);
		StartCoroutine(UpdateFunc());
	}

	//void Update()
	//{



	//}
	IEnumerator UpdateFunc()
    {
		viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
		UpdateVisibleChunks();
		yield return new WaitForSeconds(0.1f);
		viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
		UpdateVisibleChunks();
		yield return new WaitForSeconds(0.1f);
		viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
		UpdateVisibleChunks();
		yield return new WaitForSeconds(0.1f);
		viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
		UpdateVisibleChunks();
		yield return new WaitForSeconds(0.1f);
		viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
		UpdateVisibleChunks();
		yield return new WaitForSeconds(0.1f);
		viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
		UpdateVisibleChunks();
		yield return new WaitForSeconds(0.1f);
		while (true)
        {
			viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
			UpdateVisibleChunks();
			yield return new WaitForSeconds(1);
		}
    }
	void UpdateVisibleChunks()
	{
		for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
		{
			terrainChunksVisibleLastUpdate[i].SetVisible(false);
		}
		terrainChunksVisibleLastUpdate.Clear();

		int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x / chunkSize);
		int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunkSize);

		for (int yOffset = -chunksVisibleInViewDst; yOffset <= chunksVisibleInViewDst; yOffset++)
		{
			for (int xOffset = -chunksVisibleInViewDst; xOffset <= chunksVisibleInViewDst; xOffset++)
			{
				Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

				if (terrainChunkDictionary.ContainsKey(viewedChunkCoord))
				{
					terrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk();
					if (terrainChunkDictionary[viewedChunkCoord].IsVisible())
					{
						terrainChunksVisibleLastUpdate.Add(terrainChunkDictionary[viewedChunkCoord]);
					}
				}
				else
				{
					terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, chunkSize));
				}

			}
		}
	}

	public class TerrainChunk
	{
		GameObject meshObject;
		Vector2 position;
		Bounds bounds;
		public TerrainChunk(Vector2 coord, int size)
		{
			position = coord * size;
			bounds = new Bounds(position, Vector2.one * size);
			Vector3 positionV3 = new Vector3(position.x, 0f, position.y);

			//meshObject = Instantiate(instance.Maps, positionV3, Quaternion.identity);
			meshObject = ObjectPooler.SpawnFromPool("Map", positionV3, Quaternion.identity); ;
			meshObject.transform.localScale = Vector3.one * size / 10f;
			SetVisible(false);
		}
		public void UpdateTerrainChunk()
		{
			float viewerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPosition));
			bool visible = viewerDstFromNearestEdge <= maxViewDst;
			SetVisible(visible);
		}

		public void SetVisible(bool visible)
		{
			meshObject.SetActive(visible);
		}
		public bool IsVisible()
		{
			return meshObject.activeSelf;
		}
	}
}