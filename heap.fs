module Heap

type heap<'k,'v> = Empty | Heap of 'k * 'v * list<heap<'k,'v>>

let findmin h = match h with
                | Heap(_,v,_) -> v
                | Empty -> failwith "Can't findmin of Empty heap."

let merge h1 h2 = match (h1,h2) with
                  | Empty,h | h,Empty -> h
                  | Heap(k1,v1,h1s),Heap(k2,v2,h2s) -> if k1 < k2 then Heap(k1,v1,h2::h1s) else Heap(k2,v2,h1::h2s)

let deletemin h = 
    let rec red xs = 
        match xs with
        | x::y::xs -> merge (merge x y) (red xs)
        | [x] -> x
        | [] -> Empty
    match h with
    | Heap(_,_,hs) -> red hs
    | Empty -> failwith "Can't deletemin of Empty heap."

let insert h k v = merge h (Heap(k,v,[]))

let fromlist key xs = xs |> List.fold (fun h x -> insert h (key x) x) Empty
let rec tolist h =
    match h with
    | Empty -> []
    | _ -> findmin h :: tolist (deletemin h)