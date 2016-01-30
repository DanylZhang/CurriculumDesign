package calculator;

/*一、中缀式转后缀式(逆波兰式)算法：
 *  1.当当前字符为运算符时，包括 "(",")" ：
 *    a.当当前字符为")"时，则弹出堆栈中最上的"("之前的所有运算符并输出到RPN_expression，然后删除栈中最上面的"("
 *    b.当当前字符非")"时，依次弹出堆栈中优先级大于等于当前运算符的，存入RPN_expression，再将当前运算符压栈
 *  2.当当前字符为数字时，直接输出到RPN_expression；
 *  3.当当前字符为"="时，弹出所有栈中的内容存入RPN_expression；
 *二、计算逆波兰表达式算法：
 *  1.建立一个栈，然后从左至右扫描RPN_expression，每遇到运算数就压入栈中，每遇到运算符号，就弹出栈顶的两个运算数
 *  2.完成相应的运算并把结果再压入栈中，最后的结果将保留在栈顶
 *  3.返回运算结果*/
import java.math.BigDecimal;
import java.util.Stack;

public class Calculate {

	public static BigDecimal Main(String str) throws Exception {
		String RPN_Expression = toRPN(str);
		return calculateRPN(RPN_Expression);
	}

	private static int priority(char c) {// 判断优先级
		switch (c) {
		case '+':
		case '-':
			return 1;
		case '*':
		case '÷':
		case '%':
			return 2;
		case '^':
			return 3;
		case '﹣':
			return 4;
		case '√':
			return 5;
		case '(':
			return 6;
		default:
			return 0;
		}
	}

	private static String toRPN(String str) throws Exception {
		StringBuffer RPN_expression = new StringBuffer();
		Stack<Character> operator = new Stack<Character>();
		operator.push('=');
		int i = 0;
		char ch = str.charAt(i);

		while (ch != '=') {
			if (ch == '+' || ch == '-' || ch == '*' || ch == '÷' || ch == '%'
					|| ch == '^' || ch == '√' || ch == '﹣' || ch == '('
					|| ch == ')') {// 1.当当前字符为运算符时，包括 "(",")" ：
				if (ch == ')') {// a.当当前字符为")"时，则弹出堆栈中最上的"("之前的所有运算符并输出到RPN_expression，然后删除栈中最上面的"("
					char temp = operator.peek();
					while (temp != '(') {
						RPN_expression.append(temp);
						operator.pop();
						temp = operator.peek();
					}
					operator.pop();
					ch = str.charAt(++i);
				} else {// b.当当前字符非")"时，依次弹出堆栈中优先级大于等于当前运算符的，存入RPN_expression，再将当前运算符压栈
					char temp = operator.peek();
					while (priority(temp) >= priority(ch) && temp != '(') {
						RPN_expression.append(temp);
						operator.pop();
						temp = operator.peek();
					}
					operator.push(ch);
					ch = str.charAt(++i);
				}
			} else {// 2.当当前字符为数字时，直接输出到RPN_expression；
				if (!(('0' <= ch && ch <= '9') || ch == '.'))
					throw new Exception("非法字符！");
				while (('0' <= ch && ch <= '9') || ch == '.') {
					RPN_expression.append(ch);
					ch = str.charAt(++i);
				}
				RPN_expression.append('#');// '#'用来隔离运算数
			}
		}
		ch = operator.pop();
		while (ch != '=') {// 3.当当前字符为"="时，弹出所有栈中的内容存入RPN_expression；
			RPN_expression.append(ch);
			ch = operator.pop();
		}
		RPN_expression.append('=');
		return RPN_expression.toString();
	}

	private static BigDecimal calculateRPN(String str) throws Exception {
		Stack<BigDecimal> stack = new Stack<BigDecimal>();
		BigDecimal num1, num2;
		StringBuffer operand;
		int i = 0;
		while (str.charAt(i) != '=') {
			operand = new StringBuffer();
			if ('0' <= str.charAt(i) && str.charAt(i) <= '9') {
				while (('0' <= str.charAt(i) && str.charAt(i) <= '9')
						|| str.charAt(i) == '.') {
					operand.append(str.charAt(i++));
				}
				try {
					stack.push(new BigDecimal(operand.toString()));
				} catch (Exception e) {
					throw new Exception("含非法小数点！");
				}
			} else if (str.charAt(i) == '#') {
				i++;
			} else if (str.charAt(i) == '+') {
				if (stack.size() < 2)
					throw new Exception("缺少计算数！");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push(num1.add(num2));
				i++;
			} else if (str.charAt(i) == '-') {
				if (stack.size() < 2)
					throw new Exception("缺少计算数！");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push(num2.subtract(num1));
				i++;
			} else if (str.charAt(i) == '*') {
				if (stack.size() < 2)
					throw new Exception("缺少计算数！");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push(num1.multiply(num2));
				i++;
			} else if (str.charAt(i) == '÷') {
				if (stack.size() < 2)
					throw new Exception("缺少计算数！");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push((num2.divide(num1, 12, BigDecimal.ROUND_HALF_EVEN))
						.stripTrailingZeros());
				i++;
			} else if (str.charAt(i) == '%') {
				if (stack.size() < 2)
					throw new Exception("缺少计算数！");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push(num2.remainder(num1));
				i++;
			} else if (str.charAt(i) == '^') {
				if (stack.size() < 2)
					throw new Exception("缺少计算数！");
				num1 = stack.pop();
				num2 = stack.pop();
				if (num1.intValue() < 0)
					throw new Exception("指数不能小于零！");
				else
					stack.push(num2.pow(num1.intValue()));
				i++;
			} else if (str.charAt(i) == '﹣') {
				if (stack.size() < 1)// 负号为单目运算符
					throw new Exception("缺少计算数！");
				num1 = stack.pop();
				stack.push(num1.negate());
				i++;
			} else if (str.charAt(i) == '√') {
				if (stack.size() < 1)// 开方为单目运算符
					throw new Exception("缺少计算数！");
				num1 = stack.pop();
				if (num1.intValue() < 0)
					throw new Exception("被开方数不能小于零！");
				stack.push(new BigDecimal(Math.sqrt(num1.doubleValue())));
				i++;
			}
		}
		if (stack.size() != 1)// 每次算完栈中应只剩一个运算数
			throw new Exception("缺少计算数！");
		return stack.pop();
	}
}