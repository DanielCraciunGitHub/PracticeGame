 using UnityEngine;

 namespace Packages.Spawning.VectorPropertyDrawer
 {
     public class VectorLabelsAttribute : PropertyAttribute
     {
         public readonly string[] labels;
 
         public VectorLabelsAttribute( params string[] labels )
         {
             this.labels = labels;
         }
     }
 }