== Functional F# two pass pairing heap ==

A heap is a data structure that is able to hold key value pairs in sorted order compared by key. The two basic operations are inserting a key value pair into a heap, and finding/deleting the key value pair with minimum key. This implementation also allows you to merge two heaps, and to convert from and to lists. Note that this is a functional (immutable) implementation, so inserting a value doesn't mutate the heap, but rather returns a new heap with the key value pair added.

Usage:

* Heap.Empty
* Heap.insert heap key value
* Heap.findmin heap
* Heap.deletemin heap
* Heap.merge heap1 heap2
* Heap.fromlist keyfn xs
* Heap.tolist heap

Example:

The sortBy function can be written like this:

let sortBy keyfn xs = Heap.tolist (Heap.fromlist key xs)

Note that this is a O(n log n) sorting algorithm.