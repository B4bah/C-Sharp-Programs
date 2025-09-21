def read_vectors_from_file(filename):
    with open(filename, 'r') as file:
        lines = file.readlines()
        x = tuple(map(float, lines[0].strip().split()))
        y = tuple(map(float, lines[1].strip().split()))
    return x, y


def add_up_vectors(vector1, vector2):
    return (vector1[0] + vector2[0], vector1[1] + vector2[1])