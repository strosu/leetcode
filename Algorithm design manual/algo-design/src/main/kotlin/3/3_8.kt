package a1_2.`3`

class NewNode(var value: Int) {
    var leftChildren: Int = 0
    var left: NewNode? = null
    var right: NewNode? = null
    var parent: NewNode? = null

    fun goesLeft(value: Int) : Boolean {
        return this.value <= value
    }
}

open class TreeGeneric {
    private var root: NewNode? = null

    fun delete(orderedPosition: Int) {
    }

    fun deleteWithIndexRecursively(position: Int, currentNode: NewNode) {
        if (currentNode == null) {
            throw IllegalArgumentException("not enough elements")
        }

        if (currentNode.leftChildren >= position) {
            return deleteWithIndexRecursively()
        }
    }
sa
    fun delete(targetNode: NewNode) {
        if (targetNode.left == targetNode.right == null) {
            targetNode.parent = null
            if (targetNode == root) {
                root = null
            }

            return
        }

        if (targetNode.right == null) {
            if (targetNode.parent!!.left == targetNode) {
                targetNode.parent!!.left = targetNode.left
            }
            else {
                targetNode.parent!!.right = targetNode.left
            }

            return
        }

        if (targetNode.left == null) {
            if (targetNode.parent!!.left == targetNode) {
                targetNode.parent!!.left = targetNode.right
            }
            else {
                targetNode.parent!!.right = targetNode
            }

            return
        }

        // Has both children
        val precursor = getPrecursor(targetNode)
        targetNode.value = precursor.value
        targetNode.leftChildren--
        delete(precursor)
    }

    private fun getPrecursor(targetNode: NewNode): NewNode {
        var result = targetNode.left
        while (result?.right != null) {
            result = result.right
        }

        return result!!
    }

    fun contains(value: Int) : Boolean {
        return containsRecursively(root, value)
    }

    private fun containsRecursively(currentNode: NewNode?, value: Int): Boolean {
        if (currentNode == null) {
            return false
        }

        if (currentNode.goesLeft(value)) {
            return containsRecursively(currentNode.left, value)
        }

        return containsRecursively(currentNode.right, value)
    }

    fun insert(value: Int) {
        if (root == null) {
            root = NewNode(value)
            return
        }

        if (root!!.goesLeft(value)) {
            root!!.leftChildren++
            insertRecursively(value, root!!.left, root!!, true)
        }
        else {
            insertRecursively(value, root!!.right, root!!, false)
        }

    }

    private fun insertRecursively(value: Int, currentNode: NewNode?, parent: NewNode, isLeftChild: Boolean) {
        if (currentNode == null) {
            val newNode = NewNode(value)

            if (isLeftChild) {
                parent.left = newNode
                return
            }
            else {
                parent.right = newNode
                return
            }
        }

        if (currentNode.goesLeft(value)) {
            currentNode.leftChildren++
            insertRecursively(value, currentNode.left, currentNode, true)
        }
        else {
            insertRecursively(value, currentNode.right, currentNode, false)
        }
    }
}

class `3_8` {
}