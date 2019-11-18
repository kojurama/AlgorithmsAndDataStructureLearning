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

    /* recursively begins or continues a tree with an if statement
    seeing if any root node yet contains data. Then if a root does
    exist it navigates it through the tree using if statements of greater
    or smaller, triggering recursively until there is no node which
    will trigger the creation of a node with that value.
    */
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

    /* 1st method for finding if the tree does contain a certain value
    by traversing the tree and returning true when value is found.
    How every if the traversal ends at a null node, then the data is
    not contained and returns false */
    private boolean containsNodeRecursive(Node root, int value) {
        if (root == null) {
            return false;
        }

        if (value == root.value) {
            return true;
        }
        // if less than is true, continue left. If not then go right.
        return value < root.value
                ? containsNodeRecursive(root.left, value)
                : containsNodeRecursive(root.right, value);
    }

    /* Starts at root and continues left gradually getting smaller.
    It recursively goes through left nodes of tree looking for the end
    which will be a null value. If it doesn't find then it continues left.
    If the current node does not have a left value then the current node
    will be the smallest and will be returned. */
    private int findSmallestValue(Node root) {
        return root.left == null ? root.value : findSmallestValue(root.left);
    }

    public void delete(int value) {
        root = deleteRecursive(root, value);
    }

    /* Similar to the add method we have a delete method that functions recursively
    by looking for the value we are trying to delete. If value isn't found then
    return null. If value is found than multiple cases are required for whether it
    has child nodes or not so that we can maintain the binary structure of the tree. */
    private Node deleteRecursive(Node current, int value) {
        if (current == null) {
            return null;
        }

        if (value == current.value) {
                // Case 1: no children nodes
                if (current.left == null && current.right == null) {
                    return null;
                }
            // Case 2: 1 child node
            if (current.right == null) {
                return current.left;
            }
            if (current.left == null) {
                return current.right;
            }
            /* Case 3: 2 children nodes- the right node will be bigger than
            the left node so when a root node is removed the right node can
            move up to take the place of the root and the binary structure
            will still be maintained. */
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