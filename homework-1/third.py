# class Point:

#     def __init__(self, x, y):
#         self.x = x
#         self.y = y
    

# class Rect:

#     def __init__(self, point_1: Point, point_2: Point):
#         self.left_bot_point = point_1
#         self.right_top_point = point_2

#         self.bot_side = abs(point_1.x - point_2.x)
#         self.left_side = abs(point_1.y - point_2.y)
    
#     def calculate_perimetr(self):
#         return (self.bot_side + self.left_side) * 2
    
#     def calculate_square(self):
#         return self.bot_side * self.left_side



# point1 = Point(0, 0)
# point2 = Point(4, 2)

# rect = Rect(point1, point2)

# perimetr = rect.calculate_perimetr()
# square = rect.calculate_square()

# print(perimetr, square)


def get_point_input(prompt):
    x, y = map(float, input(prompt).split())
    return x, y


def calculate_area(top_left, bottom_right):
    width = abs(bottom_right[0] - top_left[0])
    height = abs(top_left[1] - bottom_right[1])
    return width * height


def calculate_perimeter(top_left, bottom_right):
    width = abs(bottom_right[0] - top_left[0])
    height = abs(top_left[1] - bottom_right[1])
    return 2 * (width + height)


def display_results(area, perimeter):
    print(f"Area: {area:.2f}")
    print(f"Perimeter: {perimeter:.2f}")