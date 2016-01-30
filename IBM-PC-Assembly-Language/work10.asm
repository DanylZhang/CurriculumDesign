data segment
 ENG db 'THE SUN CAME OUT, WHAT COLOR SHOULD I CHOOSE FOR MY SSUNGLASSUNS?$'
 len_ENG equ $-ENG-1
 SUN db 'SUN',0h,'$'
 len_SUN equ $-SUN-1
data ends

mystack segment
 stack1 dw 5 dup(?)
mystack ends

code segment
assume cs:code,ds:data,ss:mystack
start:
mov ax,data
mov ds,ax
mov es,ax
mov ax,mystack
mov ss,ax
mov sp,10

showENG:
lea dx,ENG
mov ah,9
int 21h

crlf:
mov dl,0dh
mov ah,2
int 21h
mov dl,0ah
mov ah,2
int 21h

showSUN:
lea dx,SUN
mov ah,9
int 21h

sub ax,ax
mov si,0
compare:
cmp si,len_ENG-2
jg store
mov cx,len_SUN
lea di,SUN
cld
repe cmpsb
cmp cx,2
jg compare
cmp cx,0
jg substract
inc ax
jmp compare
substract:
dec si
jmp compare

store:
mov bx,10
cwd
div bx
push dx
cmp ax,0
jnz store

mov dl,'='
mov ah,2
int 21h
mov dl,20h
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