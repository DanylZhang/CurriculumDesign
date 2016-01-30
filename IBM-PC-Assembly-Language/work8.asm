code segment
assume cs:code
start:
mov ax,1101101010110100b

mov dl,0
mov ch,9
mov cl,2
next:
mov bx,ax
shr ax,cl
dec ch
jz print
and bx,0000000000000011b
cmp bx,3
jne next
inc dl
jmp next

print:
add dl,30h
mov ah,2
int 21h
mov ah,7
int 21h
mov ax,4c00h
int 21h
code ends
end start