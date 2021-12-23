# DataStructure
数据结构：线性表，栈与队列，树与二叉树，图
<p>对于本次学习的数据结构进行总结整理。</p>
<p>Array：数组，连续内存</p>
<p>LinkedList：链表，非连续内存，节点值+下一节点地址，头节点</p>
<p>Stack：栈，后入先出，Push，Pop，Peek，栈底栈顶</p>
<p>Queue：队列，先入先出，Enqueue，Dequeue，Peek，队首队尾</p>
<p>实现数据结构包括：</p>
<table style="height: 139px; width: 1144px;" border="0">
<tbody>
<tr>
<td>名称</td>
<td>AddFirst</td>
<td>AddLast</td>
<td>Get</td>
<td>Set</td>
<td>Contains</td>
<td>RemoveFirst</td>
<td>RemoveLast</td>
</tr>
<tr>
<td>Array1，动态数组</td>
<td>O(n)</td>
<td>O(1)</td>
<td>O(1)</td>
<td>O(1)</td>
<td>O(n)</td>
<td>O(n)</td>
<td>O(1)</td>
</tr>
<tr>
<td>Array2，循环数组</td>
<td>&nbsp;</td>
<td>O(1)</td>
<td>O(1)</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>O(1)</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>LinkedList1，链表</td>
<td>O(1)</td>
<td>O(n)</td>
<td>O(n)</td>
<td>O(n)</td>
<td>O(n)</td>
<td>O(1)</td>
<td>O(n)</td>
</tr>
<tr>
<td>LinkedList2，带尾指针的链表</td>
<td>&nbsp;</td>
<td>O(1)</td>
<td>O(1)</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>O(1)</td>
<td>&nbsp;</td>
</tr>
</tbody>
</table>
<p>Array1Stack：动态数组栈，全部为O(1)。<span style="color: #ff0000;">系统提供了Stack</span></p>
<p><span style="color: #000000;">Array1Queue：动态数组队列，使用动态数组的First为队首，Dequeue O(n)</span></p>
<p>Array2Queue：循环数组队列，全部为O(1)。<span style="color: #ff0000;">系统提供了Queue</span></p>
<p><span style="color: #000000;">LinkedList1Queue：链表队列，使用链表的Last为队首，Enqueue O(n)</span></p>
<p><span style="color: #000000;">LinkedList1Set：链表集合，全部为O(n)</span></p>
<p><span style="color: #000000;">LinkedList1Stack：链表栈，全部为O(1)。需要new节点，性能不如Array1Stack</span></p>
<p><span style="color: #000000;">LinkedList2Queue：带尾指针的链表的队列，全部为O(1)。需要new节点，性能不如Array2Queue</span></p>
<p>LinkedList3：链表键值</p>
<p><span style="color: #000000;">LinkedList3Dictionary：链表映射</span></p>
<p><span style="color: #000000;">SortedArray1：有序数组。由于集合需要判断Contain，由连续查找改为</span><span style="color: #ff0000;">二分查找</span><span style="color: #000000;">，获得有序数组。</span></p>
<p><span style="color: #000000;">SortedArray1Set：有序数组集合。Contains为O(log n)。<span style="color: #ff0000;">系统提供了SortedList</span></span></p>
<p><span style="color: #000000;">SortedArray2：有序数组键值对。</span></p>
<p><span style="color: #000000;">SortedArray2Dictionary：有序数组映射。Add仍为O(n)</span></p>
<p><span style="color: #000000;">BST1：二叉树，递归，前序遍历中序遍历后序遍历（深度优先），层序遍历（广度优先），支持Min，Max，树高</span></p>
<p><span style="color: #000000;">BST1Set：二叉树集合</span></p>
<p><span style="color: #000000;">BST2：二叉树键值</span></p>
<p><span style="color: #000000;">BST2Dictionary：二叉树映射，二叉树对有序数据的构建不好</span></p>
<p><span style="color: #000000;">RBT1：左倾红黑树，二叉树为了平衡，左旋，右旋，颜色翻转</span></p>
<p><span style="color: #000000;">RBT1Set：红黑树集合。<span style="color: #ff0000;">系统提供了SortedSet</span></span></p>
<p><span style="color: #000000;">RBT2：红黑树键值对</span></p>
<p><span style="color: #000000;">RBT2Dictionary：红黑树映射。<span style="color: #ff0000;">系统提供了SortedDictionary</span></span></p>
<p><span style="color: #000000;">HashST1：哈希表，哈希函数，哈希冲突</span></p>
<p><span style="color: #000000;">HashST1Set：哈希表集合，不支持最大最小等。<span style="color: #ff0000;">系统提供了HashSet</span></span></p>
<p><span style="color: #000000;">HashST2：哈希表键值对</span></p>
<p><span style="color: #000000;">HashST2Dictionary：哈希表字典。<span style="color: #ff0000;">系统提供了Dictionary</span></span></p>
