dataseg segment
 DATA dw 1,4,3,6,5,2,7,8,9,10
      dw 90 dup(20)			;后面90个数用20补
 string db 'The smallest even number: $'
dataseg ends

mystack segment
 stack1 dw 10 dup(?)
mystack ends

code segment
assume cs:code,ds:dataseg,ss:mystack
start:
mov ax,dataseg
mov ds,ax
mov ax,mystack
mov ss,ax
mov sp,10

;先找到一个偶数
mov bx,0
mov dl,2
findFirst:
cmp bx,200
je exit
mov ax,DATA[bx]
add bx,2
div dl
cmp ah,0
jnz findFirst

sub bx,2
mov si,bx
findLittle:
cmp bx,198
je foundOne
add bx,2
mov ax,DATA[bx]
div dl
cmp ah,0
jnz findLittle

mov ax,DATA[si]
cmp ax,DATA[bx]
jle findLittle
mov si,bx
jmp findLittle

foundOne:
mov ax,DATA[si]
mov bx,10
mov cx,6
loop1:
cwd
div bx
push dx
cmp ax,0
loopnz loop1

print:
lea dx,string
mov ah,9
int 21h

mov cx,6
loop2:
pop dx
add dl,30h
mov ah,2
int 21h
cmp sp,10
loopne loop2		;输出结果

exit:
mov dl,0dh
mov ah,2
int 21h
mov dl,0ah
mov ah,2
int 21h
mov ah,7
int 21h
mov ax,4c00h
int 21h
code ends
end start