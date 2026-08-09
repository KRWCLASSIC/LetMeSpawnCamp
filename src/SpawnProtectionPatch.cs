using HarmonyLib;
using UnityEngine;

namespace LetMeSpawnCamp
{
    [HarmonyPatch(typeof(CheckColliding))]
    public class SpawnProtectionPatch
    {
        [HarmonyPatch("handleCollision")]
        [HarmonyPrefix]
        public static bool HandleCollisionPrefix(CheckColliding __instance, GameObject go)
        {
            if (go == null) return true;

            CollisionTag goTag = go.GetComponent<CollisionTag>();
            if (goTag == null) goTag = go.GetComponentInParent<CollisionTag>();
            if (goTag == null) goTag = go.GetComponentInChildren<CollisionTag>();
            
            if (goTag != null && (goTag.ContainsAnyTag(TagComparer.Tag.StartProtection) || goTag.ContainsAnyTag(TagComparer.Tag.Start) || goTag.ContainsAnyTag(TagComparer.Tag.Respawn)))
            {
                CollisionTag myTag = __instance.GetComponent<CollisionTag>();
                bool isSolid = myTag != null && (myTag.ContainsAnyTag(TagComparer.Tag.Solid) || myTag.ContainsAnyTag(TagComparer.Tag.SolidNotWall));
                
                if (!isSolid)
                {
                    Placeable placeable = __instance.GetComponentInParent<Placeable>();
                    bool hasSolidPart = false;
                    if (placeable != null)
                    {
                        foreach (CheckColliding col in placeable.GetComponentsInChildren<CheckColliding>(true))
                        {
                            if (col != null)
                            {
                                CollisionTag cTag = col.GetComponent<CollisionTag>();
                                if (cTag != null && (cTag.ContainsAnyTag(TagComparer.Tag.Solid) || cTag.ContainsAnyTag(TagComparer.Tag.SolidNotWall)))
                                {
                                    hasSolidPart = true;
                                    break;
                                }
                            }
                        }
                    }

                    // Only bypass the StartZone collision if this is a non-solid part (like attack range) 
                    // AND the trap actually has a solid base elsewhere (like Boxing Glove, Wrecking Ball).
                    // This blocks pure hazards like Spikes from being placed directly on the spawn.
                    if (hasSolidPart)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [HarmonyPatch("CheckCollidingObject")]
        [HarmonyPrefix]
        public static bool CheckCollidingObjectPrefix(CheckColliding __instance, GameObject go, ref bool __result)
        {
            if (go == null) return true;

            CollisionTag goTag = go.GetComponent<CollisionTag>();
            if (goTag == null) goTag = go.GetComponentInParent<CollisionTag>();
            if (goTag == null) goTag = go.GetComponentInChildren<CollisionTag>();

            if (goTag != null && (goTag.ContainsAnyTag(TagComparer.Tag.StartProtection) || goTag.ContainsAnyTag(TagComparer.Tag.Start) || goTag.ContainsAnyTag(TagComparer.Tag.Respawn)))
            {
                CollisionTag myTag = __instance.GetComponent<CollisionTag>();
                bool isSolid = myTag != null && (myTag.ContainsAnyTag(TagComparer.Tag.Solid) || myTag.ContainsAnyTag(TagComparer.Tag.SolidNotWall));

                if (!isSolid)
                {
                    Placeable placeable = __instance.GetComponentInParent<Placeable>();
                    bool hasSolidPart = false;
                    if (placeable != null)
                    {
                        foreach (CheckColliding col in placeable.GetComponentsInChildren<CheckColliding>(true))
                        {
                            if (col != null)
                            {
                                CollisionTag cTag = col.GetComponent<CollisionTag>();
                                if (cTag != null && (cTag.ContainsAnyTag(TagComparer.Tag.Solid) || cTag.ContainsAnyTag(TagComparer.Tag.SolidNotWall)))
                                {
                                    hasSolidPart = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (hasSolidPart)
                    {
                        __result = false; 
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
