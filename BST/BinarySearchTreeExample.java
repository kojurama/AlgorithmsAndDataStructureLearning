import java.util.LinkedList;
import java.util.Queue;

class BinarySearchTreeExample {
    class Node {
        int value;
        Node left;
        Node right;

        Node(int value) {
            this.value = value;
            left = right = null;
        }
    }

    Node root;

    // establishing BST
    BinarySearchTreeExample() {
        root = null;
    }

    void insert(int value) {
        root = insertRecursive(root, value);
    }

    Node insertRecursive(Node root, int value) {
        if (root == null) {
            root = new Node(value);
            return root;
        }

        if (value < root.value) {
            root.left = insertRecursive(root.left, value);
        }
        else if (value > root.value) {
            root.right = insertRecursive(root.right, value);
        }

        return root;
    }

    /* starts the search method at the root and then uses the
   search method to traverse the nodes looking for the value
    */
    public boolean containsNode(int value) {
        return containsNodeRecursive(root, value);
    }

    //1st method for BST traversal to find a specific node
    private boolean containsNodeRecursive(Node root, int value) {
        if (root == null) {
            return false;
        }

        if (value == root.value) {
            return true;
        }

        return value < root.value
                ? containsNodeRecursive(root.left, value)
                : containsNodeRecursive(root.right, value);
    }

    private int findSmallestValue(Node root) {
        return root.left == null ? root.value : findSmallestValue(root.left);
    }

    public void delete(int value) {
        root = deleteRecursive(root, value);
    }

    // delete method
    private Node deleteRecursive(Node current, int value) {
        if (current == null) {
            return null;
        }

        if (value == current.value) {
            // Case 1: no children
            if (current.left == null && current.right == null) {
                return null;
            }
            // Case 2: 1 child
            if (current.right == null) {
                return current.left;
            }
            if (current.left == null) {
                return current.right;
            }
            // Case 3: 2 children--- hard to understand
            int smallestValue = findSmallestValue(current.right);
            current.value = smallestValue;
            current.right = deleteRecursive(current.right, smallestValue);
            return current;
        }

        if (value < current.value) {
            current.left = deleteRecursive(current.left, value);
            return current;
        }
        current.right = deleteRecursive(current.right, value);

        return current;
    }

    // in-order traversal, ie left, root, right.
    public void traverseInOrder(Node node) {
        if (node != null) {
            traverseInOrder(node.left);
            System.out.print(" " + node.value);
            traverseInOrder(node.right);
        }
    }

    // pre-order traversal, ie root, left, right
    public void traversePreOrder(Node node) {
        if (node != null) {
            System.out.print(" " + node.value);
            traversePreOrder(node.left);
            traversePreOrder(node.right);
        }
    }

    // post-order traversal, ie left, right, root
    public void traversePostOrder(Node node) {
        if (node != null) {
            traversePostOrder(node.left);
            traversePostOrder(node.right);
            System.out.print(" " + node.value);
        }
    }

    // breadth first search/ level order search
    public void traverseLevelOrder() {
        if (root == null) {
            return;
        }

        Queue<Node> nodes = new LinkedList<>();
        while (!nodes.isEmpty()) {
            Node node = nodes.remove();

            System.out.print(" " + node.value);

            if (node.left != null) {
                nodes.add(node.left);
            }

            if (node.right != null) {
                nodes.add(node.right);
            }
        }
    }

     /* begins the 2nd BST traversal at the root
    void inOrder() {
        inOrderRec(root);
    }

    2nd method for BST traversal to find specific node,
    unsure of which I like more
    void inOrderRec(Node root) {
        if (root != null) {
            inOrderRec(root.left);
            System.out.println(root.value);
            inOrderRec(root.right);
        }
    }*/



    // creation method
    private BinarySearchTreeExample createBinaryTree() {
        BinarySearchTreeExample bt = new BinarySearchTreeExample();

        bt.insert(19);
        bt.insert(9);
        bt.insert(23);
        bt.insert(33);
        bt.insert(7);
        bt.insert(2);
        bt.insert(11);

        return bt;
    }

    /* need to download and import Junit for this test
    @test
    public void whenAddingElements_TreeContainsElements() {
        BinarySearchTreeExample bt = createBinaryTree();

        assertTrue(bt.containsNode(6));
    }

     */

}