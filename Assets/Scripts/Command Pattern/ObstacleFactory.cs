//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using UnityEngine;
//
//namespace simpleFactory
//{
//    public abstract class Obstacle
//    {
//        public List<Transform> shapes;
//
//        public abstract void PlaceShape(Vector3 position, Transform shape);
//
//        public abstract void RemoveShape(Vector3 position);
//
//    }
//
//    public class enemyObstacle : Obstacle
//    {
//        public override void PlaceShape(Vector3 position, Transform shape)
//        {
//            Transform newShape = Transform.Instantiate(shape, position, Quaternion.identity);
//            //newCube.GetComponentInChildren<MeshRenderer>().material.color = color;
//            if (shapes == null)
//            {
//                shapes = new List<Transform>();
//            }
//            shapes.Add(newShape);
//        }
//
//        public override void RemoveShape(Vector3 position)
//        {
//            for (int i = 0; i < shapes.Count; i++)
//            {
//                if (shapes[i].position == position)
//                {
//                    GameObject.Destroy(shapes[i].gameObject);
//                    shapes.RemoveAt(i);
//                    break;
//                }
//            }
//        }
//    }
//
//    public class ObstacleFactory
//    {
//        public Obstacle GetObstacle(string obstacleType)
//        {
//            switch (obstacleType)
//            {
//                case "enemy":
//                    return new enemyObstacle();
//                default:
//                    return null;
//            }
//        }
//    }
//}