class LRUCache {
public:
    class Node {
    public:
        int key;
        int val;
        Node* next;
        Node* prev;
        Node(int _key, int _val) : key(_key), val(_val), next(nullptr), prev(nullptr) {}
    };
    
    Node* head;
    Node* tail;
    int cap;
    unordered_map<int, Node*> mpp;

    LRUCache(int capacity) {
        cap = capacity;
        head = new Node(-1, -1);
        tail = new Node(-1, -1);
        head->next = tail;
        tail->prev = head;
    }

    void insertNode(Node* node) {
        Node* temp = head->next;
        head->next = node;
        node->next = temp;
        temp->prev = node;
        node->prev = head;
    }

    void deleteNode(Node* node) {
        Node* delprev = node->prev;
        Node* delnext = node->next;
        delprev->next = delnext;
        delnext->prev = delprev;
    }

    int get(int key) {
        if (mpp.find(key) != mpp.end()) {
            Node* res = mpp[key];
            deleteNode(res);
            insertNode(res);
            return res->val;
        }
        return -1;
    }

    void put(int key, int value) {
        if (mpp.find(key) != mpp.end()) {
            Node* curr = mpp[key];
            deleteNode(curr);
            curr->val = value;
            insertNode(curr);
            mpp[key] = head->next;
        } else {
            if (mpp.size() == cap) {
                Node* lru = tail->prev;
                mpp.erase(lru->key);
                deleteNode(lru);
                delete lru; // Free memory
            }
            Node* newNode = new Node(key, value);
            insertNode(newNode);
            mpp[key] = newNode;
        }
    }
};