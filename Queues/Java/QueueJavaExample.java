class QueueJavaExample {
    private static class Node {
        private int data;
        private Node next;
        private Node(int data) {
            this.data = data;
        }
    }

    // 2 nodes, one for begining and end
    private Node head;
    private Node tail;

    public boolean isEmpty() {
        return head == null;
    }

    public int peek() {
        if (head.data == null) {
            return null;
        }
        return head.data;
    }

    /* In a queue you add to the end(tail) and point it.
    If there is a new queue then the node added will
    be both the tail and the head until more is added. */
    public void add(int data) {
        Node node = new Node(data);
        if (tail != null) {
            tail.next = node;
        }
        tail = node;
        if (head == null) {
            head = node;
        }
    }

    public int remove() {
        int data = head.data;
        head = head.next;
        if (head == null) {
            tail = null;
        }
        return data;
    }
}