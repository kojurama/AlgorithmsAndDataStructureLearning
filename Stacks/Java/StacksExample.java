public class StacksExample {
    private static class Node {
        private int data;
        private Node next;
        private Node(int data) {
            this.data = data;
        }
    }

    // just one node type is required as only one pointer in stack
    // which is a pointer going down the stack.
    private Node top;

    public boolean isEmpty() {
        return top == null;
    }

    public int peek () {
        return top.data;
    }

    /* Creates a node with that data and assigns its pointer
    to the top. Then we define it as the top of stack. */
    public void push(int data) {
        Node node = new Node(data);
        node.next = top;
        top = node;
    }

    /* We return the data of top node and then redefine the
    top as top.next, or next one in the stack effectively
    removing the node we just returned from the stack */
    public int pop() {
        if (top == null) {
            isEmpty();
        }
        int data = top.data;
        top = top.next;
        return data;
    }
}
