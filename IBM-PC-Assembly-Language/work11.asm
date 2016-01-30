data segment
 buff db 100 dup(?)
 count dw 0
data ends

mystack segment
 stack1 dw 5 dup(?)
mystack ends

code segment
assume cs:code,ds:data,ss:mystack
start:
mov ax,data
mov ds,ax
mov ax,mystack
mov ss,ax
mov sp,10
mov bx,0
input:
mov ah,1
int 21h
mov buff[bx],al
inc bx
cmp al,'$'
jne input

mov bx,0
next:
mov dl,buff[bx]
inc bx
cmp dl,'$'
je bin2dec
cmp dl,30h
jl cnt
cmp dl,39h
jle next
cnt:
inc count
jmp next

bin2dec:
mov ax,count
store:
mov bx,10
cwd
div bx
push dx
cmp ax,0
jnz store

crlf:
mov dl,0dh
mov ah,2
int 21h
mov dl,0ah
mov ah,2
int 21h

print:
pop dx
add dl,30h
mov ah,2
int 21h
cmp sp,10
jne print

exit:
mov ah,7
int 21h
mov ah,4ch
int 21h
code ends
end start