using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarManager : MonoBehaviour{
    public loadTile map;

    private class Node{
        public Vector3Int position;
        public Node parent;
        public float g;
        public float h;
        public float f;
        public Node(Vector3Int position, Node parent, float g, float h){
            this.position = position;
            this.parent = parent;
            this.g = g;
            this.h = h;
            this.f = g + h;
        }

        public bool Equals(Node other){
            return position == other.position;
        }
        public string toString(){
            return "Node: " + position + " g: " + g + " h: " + h + " f: " + f;
        }
    }
    private class NodeComparer : IComparer<Node>{
        public int Compare(Node x, Node y){
            if (x.f < y.f){
                return -1;
            }
            if (x.f > y.f){
                return 1;
            }
            return 0;
        }
    }

    private NodeComparer nodeComparer = new NodeComparer();

    private List<Node> openList = new List<Node>();

    private List<Node> closedList = new List<Node>();

    private List<Vector3Int> path = new List<Vector3Int>();

    private Vector3Int start;

    private Vector3Int end;

    private Vector3Int[] directions = new Vector3Int[]{
        new Vector3Int(1, 0, 0),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, -1, 0),
        new Vector3Int(1, 1, 0),
        new Vector3Int(-1, -1, 0),
        new Vector3Int(1, -1, 0),
        new Vector3Int(-1, 1, 0)
    };

    public List<Vector3Int> FindPath(Vector3Int start, Vector3Int end){
        this.start = start;
        this.end = end;
        openList.Clear();
        closedList.Clear();
        path.Clear();
        Node startNode = new Node(start, null, 0, Heuristic(start, end));
        openList.Add(startNode);
        while (openList.Count > 0){
            Node current = openList[0];
            openList.RemoveAt(0);
            closedList.Add(current);
            if (current.position == end){
                Node node = current;
                while (node != null){
                    path.Insert(0, node.position);
                    node = node.parent;
                }
                return path;
            }
            foreach (var direction in directions){
                Vector3Int neighbourPosition = current.position + direction;
                if (!checkValidTile(neighbourPosition)){
                    continue;
                }
                float g = current.g + 1;
                float h = Heuristic(neighbourPosition, end);
                Node neighbour = new Node(neighbourPosition, current, g, h);
                if (closedList.Contains(neighbour)){
                    continue;
                }
                if (openList.Contains(neighbour)){
                    int index = openList.IndexOf(neighbour);
                    if (openList[index].g > neighbour.g){
                        openList[index] = neighbour;
                    }
                }else{
                    openList.Add(neighbour);
                    openList.Sort(nodeComparer);
                }
            }
        }
        Debug.Log("path found"+path.Count);
        return path;
    }

    private float Heuristic(Vector3Int a, Vector3Int b){
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    private bool checkValidTile(Vector3Int position){
        return map.checkValidTile(position);
    }
}