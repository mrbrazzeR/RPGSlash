using Runtime.Gameplay.Resource;
using UnityEngine;

namespace Runtime.Gameplay.Character
{
    public class WoodCutter : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Update()
        {
            bool reff;
            var go = FindClosestEnemy(out reff);
            if (reff)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, go.transform.position - go.GetOffset(), 0.01f);
            }
            else
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, go.transform.position + go.GetOffset(), 0.01f);
            }
        }

        // Update is called once per frame
        public TreeWood FindClosestEnemy(out bool reff)
        {
            var left = false;
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("wood");
            TreeWood closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    if (go.transform.position.x < position.x)
                    {
                        left = true;
                    }
                    else
                    {
                        left = false;
                    }

                    closest = go.GetComponent<TreeWood>();
                    distance = curDistance;
                }
            }

            reff = left;
            return closest;
        }
    }
}