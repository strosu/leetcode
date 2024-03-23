package a1_2.structures

open class TreeNode<T : Comparable<T>>(var data: T) {
    var left: TreeNode<T>? = null
    var right: TreeNode<T>? = null
    var parent: TreeNode<T>? = null

    fun removeChild(child: TreeNode<T>) {
        replaceChild(child, null)
    }

    fun replaceChild(child: TreeNode<T>, newChild: TreeNode<T>?) {
        doBasedOnLeftOrRight(child, newChild)
    }

    private fun doBasedOnLeftOrRight(child: TreeNode<T>, newValue: TreeNode<T>?) {
        if (left == child) {
            left = newValue
        }
        if (right == child) {
            right = newValue
        }
    }
}

open class TreeGeneric<Node : TreeNode<T>, T: Comparable<T>> {
    private var root: Node? = null

    fun contains(value: T) : Boolean {
        return containsRecursively(root, value)
    }

    private fun containsRecursively(currentNode: TreeNode<T>?, value: T): Boolean {
        if (currentNode == null) {
            return false
        }

        if (currentNode.data <= value) {
            return containsRecursively(currentNode.left, value)
        }

        return containsRecursively(currentNode.right, value)
    }
}


open class Tree<T : Comparable<T>> {
    private var root: TreeNode<T>? = null

    open fun delete(target: TreeNode<T>) {
        if (target == root) {
            root = null
            return
        }

        val parent = target.parent!!

        if (target.left == null) {
            if (target.right == null) {
                parent.removeChild(target)
                return
            }

            parent.replaceChild(target, target.right)
            return
        }

        if (target.right == null) {
            parent.replaceChild(target, target.left)
            return
        }

        // Has two children, need to find the successor / predecessor
        val targetLeaf = findMin(target.left!!)
        target.data = targetLeaf.data
        targetLeaf.parent!!.removeChild(targetLeaf)
    }

    private fun findMin(currentNode: TreeNode<T>) : TreeNode<T> {
        if (currentNode.left == null) {
            return currentNode
        }

        return findMin(currentNode.left!!)
    }

    open fun insert(value: T) {
        if (root == null) {
            root = TreeNode(value)
            return
        }

        insert(value, root!!)
    }

    private fun insert(value: T, currentNode: TreeNode<T>) {
        if (value <= currentNode.data) {
            if (currentNode.left == null) {
                val newNode = TreeNode(value)
                newNode.parent = currentNode
                currentNode.left = newNode
                return
            }

            insert(value, currentNode.left!!)
            return
        }

        if (currentNode.right != null) {
            insert(value, currentNode.right!!)
            return
        }

        val newNode = TreeNode(value)
        newNode.parent = currentNode
        currentNode.right = newNode
    }
}