code segment
assume cs:code
start:
mov bx,0
mov ch,4
mov cl,4
next:
mov ah,7
int 21h
cmp al,30h
jl next
cmp al,39h
jle storeNumber
cmp al,41h
jl next
cmp al,46h
jle storeUpper
cmp al,61h
jl next
cmp al,66h
jle storeLower
jmp next

storeNumber:
mov dl,al
mov ah,2
int 21h
sub al,30h
sub ah,ah
and al,0fh
or bx,ax
dec ch
jz print
shl bx,cl
jmp next

storeUpper:
mov dl,al
mov ah,2
int 21h
sub al,37h
sub ah,ah
and al,0fh
or bx,ax
dec ch
jz print
shl bx,cl
jmp next

storeLower:
sub al,20h
mov dl,al
mov ah,2
int 21h
sub al,37h
sub ah,ah
and al,0fh
or bx,ax
dec ch
jz print
shl bx,cl
jmp next

print:
mov dl,0dh
mov ah,2
int 21h
mov dl,0ah
mov ah,2
int 21h

mov cx,16
hex2bin:
test bx,0ffffh
js print1

print0:
mov dl,30h
mov ah,2
int 21h
shl bx,1
dec cx
jz exit
jmp hex2bin

print1:
mov dl,31h
mov ah,2
int 21h
shl bx,1
dec cx
jz exit
jmp hex2bin

exit:
mov ah,7
int 21h
mov ax,4c00h
int 21h
code ends
end start