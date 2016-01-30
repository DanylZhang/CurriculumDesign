data segment
 string1 db 'Sum Calculator'
 length1 equ $-string1
 string2 db 'Made By: Zhang Danyu'
 length2 equ $-string2
 string3 db 'Student ID: 41212205'
 length3 equ $-string3
 string4 db 'Please press any key to start to calculate. '
 length4 equ $-string4
 string5 db 'Please input the first operand (0~32767): '
 length5 equ $-string5
 string6 db 'Please input the second operand (0~32767): '
 length6 equ $-string6
 string7 db 'result =  '
 length7 equ $-string7
 string8 db 'Continue to calculate?(y)  '
 length8 equ $-string8
 operand1 dw 0
 operand2 dw 0
 temp dw 1		;用作10的倍数
data ends

mystack segment
 stack1 dw 6 dup(0)
mystack ends

code segment
main proc far
assume cs:code,ds:data,ss:mystack
start:
        mov ax,data
        mov ds,ax
        call drawRectangle
print1:
        mov dh,8
        mov dl,33
        mov bl,0eh
        lea si,string1
        mov cx,length1
        call printString
print2:
        mov dh,12
        mov dl,30
        mov bl,0eh
        lea si,string2
        mov cx,length2
        call printString
print3:
        mov dh,14
        mov dl,30
        mov bl,0eh
        lea si,string3
        mov cx,length3
        call printString
print4:
        mov dh,18
        mov dl,19
        mov bl,0eh
        lea si,string4
        mov cx,length4
        call printString

        mov ah,7
        int 21h
next:
        mov ax,3
        int 10h
print5:
        mov dh,0
        mov dl,0
        mov bl,0eh
        mov ah,2
        int 10h
        mov al,' '
        mov cx,70
        mov ah,9
        int 10h

        mov dh,0
        mov dl,0
        mov bl,0eh
        lea si,string5
        mov cx,length5
        call printString
        mov ax,mystack
        mov ss,ax
        mov sp,12
        mov cx,5
loop1:
        mov ah,7
        int 21h
        cmp al,0dh	;判断输入是否是回车
        jz setOperand1
        cmp al,'0'
        jl loop1
        cmp al,'9'
        jg loop1
        mov dl,al
        mov ah,2
        int 21h
        sub al,30h
        mov ah,0
        push ax
        loop loop1
setOperand1:
        mov word ptr ds:temp[0],1
        mov word ptr ds:operand1[0],0
        mov bx,10
        mov cx,5
loop2:
        pop ax
        mul ds:temp[0]
        add ds:operand1[0],ax
        jo print5
        mov ax,ds:temp[0]
        mul bx
        mov ds:temp[0],ax
        cmp sp,12
        loopne loop2
print6:
        mov dh,2
        mov dl,0
        mov bl,0eh
        mov ah,2
        int 10h
        mov al,' '
        mov cx,70
        mov ah,9
        int 10h

        mov dh,2
        mov dl,0
        mov bl,0eh
        lea si,string6
        mov cx,length6
        call printString
        mov cx,5
loop3:
        mov ah,7
        int 21h
        cmp al,0dh	;判断输入是否是回车
        jz setOperand2
        cmp al,'0'
        jl loop3
        cmp al,'9'
        jg loop3
        mov dl,al
        mov ah,2
        int 21h
        sub al,30h
        mov ah,0
        push ax
        loop loop3
setOperand2:
        mov word ptr ds:temp[0],1
        mov word ptr ds:operand2[0],0
        mov bx,10
        mov cx,5
loop4:
        pop ax
        mul ds:temp[0]
        add ds:operand2[0],ax
        jo print6
        mov ax,ds:temp[0]
        mul bx
        mov ds:temp[0],ax
        cmp sp,12
        loopne loop4
print7:
        mov dh,5
        mov dl,0
        mov bl,0eh
        mov ah,2
        int 10h
        mov al,' '
        mov cx,70
        mov ah,9
        int 10h

        mov dh,5
        mov dl,0
        mov bl,0eh
        lea si,string7
        mov cx,length7
        call printString
        mov ax,ds:operand1[0]
        add ax,ds:operand2[0]
        mov bx,10
loops1:
        mov dx,0
        div bx
        push dx
        cmp ax,0
        jnz loops1
loops2:
        pop dx
        add dl,30h
        mov ah,2
        int 21h
        cmp sp,12
        jl loops2		;输出结果
print8:
        mov dh,8
        mov dl,0
        mov bl,0eh
        lea si,string8
        mov cx,length8
        call printString

        mov ah,1
        int 21h
        cmp al,'y'
        je dword ptr next

        mov ax,4c00h
        int 21h
        mov ax,4c00h
        int 21h
        ret
main endp

drawRectangle proc near
        push ds
        push ax
        push bx
        push cx
        push dx
        mov ax,data
        mov ds,ax

        mov ax,3
        int 10h
        mov dh,20			; current row
        mov dl,10			; current column
        mov bl,0eh		; current attributes
        mov cx,16
left:
        push cx
        call waitOneSecond
        mov ah,2
        int 10h
        mov al,'*'
        mov cx,1
        mov ah,9
        int 10h
        dec dh
        pop cx
        loop left

        mov dh,4
        mov dl,10
        mov bl,0eh
        mov cx,30
top:
        push cx
        call waitOneSecond
        mov ah,2
        int 10h
        mov al,'*'
        mov cx,1
        mov ah,9
        int 10h

        inc dl
        mov ah,2
        int 10h
        mov al,' '
        mov cx,1
        mov ah,9
        int 10h
        inc dl
        pop cx
        loop top

        mov dh,4
        mov dl,94h
        mov bl,0eh
        mov cx,16
right:
        push cx
        call waitOneSecond
        mov ah,2
        int 10h
        mov al,'*'
        mov cx,1
        mov ah,9
        int 10h
        inc dh
        pop cx
        loop right

        mov dh,20
        mov dl,94h
        mov bl,0eh
        mov cx,30
buttom:
        push cx
        call waitOneSecond
        mov ah,2
        int 10h
        mov al,'*'
        mov cx,1
        mov ah,9
        int 10h

        dec dl
        mov ah,2
        int 10h
        mov al,' '
        mov cx,1
        mov ah,9
        int 10h
        dec dl
        pop cx
        loop buttom
        pop dx
        pop cx
        pop bx
        pop ax
        pop ds
        ret
drawRectangle endp

printString proc near
        push ax
        push bx
        push cx
        push dx
        push si
print:
        push cx
        call waitOneSecond
        mov ah,2
        int 10h
        mov al,ds:[si]
        mov cx,1
        mov ah,9
        int 10h
        inc si
        inc dl
        pop cx
        loop print
        pop si
        pop dx
        pop cx
        pop bx
        pop ax
        ret
printString endp

waitOneSecond proc near
        push cx
        push dx
        mov dx,20
wait1:
        mov cx,6801
wait2:
        loop wait2
        dec dx
        jnz wait1
        pop dx
        pop cx
        ret
waitOneSecond endp
        code ends
        end start