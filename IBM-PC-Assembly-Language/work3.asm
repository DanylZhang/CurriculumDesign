data segment
 buffer db 4 dup(?)
data ends

code segment
main proc far
assume cs:code,ds:data
start:
mov ax,data
mov ds,ax

mov cl,4
mov ch,4
mov bx,0
mov ax,1234h
next:
rol ax,cl
mov dl,al
and dl,0fh
mov buffer[bx],dl
inc bx
dec ch
jnz next

mov al,buffer
mov bl,buffer+1
mov cl,buffer+2
mov dl,buffer+3
ret
main endp
code ends
end start