#ifndef DYNAMIC_ARRAY_HPP
#define DYNAMIC_ARRAY_HPP

#include "splashkit.h"
#include "utilities.h"
#include <cstdlib>
#include <new>
#include <stdexcept>
using std::to_string;

template <typename T>
struct dynamic_array {
    T* data;
    unsigned int size;
    unsigned int capacity;
};

/**
 * @brief Create a new dynamic array with the indicated initial capacity.
 *        This will return a nullptr if the array cannot be allocated.
 *
 * @tparam T the type of data the array will store
 * @param capacity its initial capacity, with a default value of 50
 * @return dynamic_array<T>* a pointer to the new dynamic array
 */
template <typename T>
dynamic_array<T> *new_dynamic_array(unsigned int capacity = 50)
{
    dynamic_array<T> *result = (dynamic_array<T>*)malloc(sizeof(dynamic_array<T>));
    if (result == nullptr)
    {
        return result;
    }
    result->data = (T*)malloc(sizeof(T) * capacity);
    result->size = 0;

    if (result->data == nullptr)
    {
        result->capacity = 0;
    }
    else
    {
       result->capacity = capacity; 
    }
    
    for (int i = 0; i < capacity; ++i)
    {
        new (&result->data[i]) T();
    }
        
    
    return result;
}

/**
 * @brief Free the memory allocated to the dynamic array. Once freed
 *        the data in the array will no longer be accessible.
 *
 * @tparam T the data type of the dynamic array
 * @param array a pointer to the dynamic array to free
 */
template <typename T>
void delete_dynamic_array(dynamic_array<T>* array)
{
    if (!array) return;
    // Call destructor for each element
    for (unsigned int i = 0; i < array->capacity; ++i)
    {
        array->data[i].~T();
    }
    array->size = 0;
    array->capacity = 0;
    free(array->data);
    array->data = nullptr;
    free(array);
}

/**
 * @brief Resize the capacity of the dynamic array.
 *
 * If the new capacity is smaller than the current size, the size
 * will be updated to match the new capacity.
 *
 * @tparam T the type of data in the dynamic array
 * @param array the dynamic array to grow
 * @param new_capacity the new capacity of the dynamic array
 * @returns true if this succeeded, or false if it could not reallocate memory
 */
template <typename T>
bool resize_dynamic_array(dynamic_array<T>* array, unsigned int new_capacity)
{
    if (!array) return false;
    // Call destructors on elements being removed
    for (int i = array->capacity - 1; i >= (int)new_capacity; --i)
    {
        array->data[i].~T();
    }
    // Reallocate memory for the data array
    T* new_data = (T*)realloc(array->data, sizeof(T) * new_capacity);
    if (new_data == nullptr)
    {
        // Out of memory
        return false;
    }
    // Call placement new for elements added when increasing size
    
    array->data = new_data;
    array->capacity = new_capacity;
    if (new_capacity < array->size)
    {
        array->size = new_capacity;
    }
    return true;
}

/**
 * @brief Add an element to the dynamic array, resizing if needed.
 *
 * @tparam T the type of data in the dynamic array
 * @param array the dynamic array to add to
 * @param value the value to add
 * @returns true if successful, false if out of memory
 */
template <typename T>
bool add_to_dynamic_array(dynamic_array<T>* array, const T& value)
{
    if (!array) return false;
    if (array->size >= array->capacity && !resize_dynamic_array(array, array->capacity * 2 + 1))
    {
        return false;
    }
    array->data[array->size] = value;
    array->size++;
    return true;
}

/**
 * @brief read and return the value of the indicated element from the dynamic array.
 *
 * If the array is not allocated or the index is out of bounds, the function will throw a string exception message.
 *
 * @tparam T the type of data in the dynamic array
 * @param array the dynamic array to remove the element from
 * @param index the index of the element to remove
 * @throws a string message if the array is not allocated or the index is invalid
 */

template <typename T>
const T& get_from_dynamic_array(const dynamic_array<T>* array, unsigned int index)
{
    if (!array)
    {
        throw string("Null dynamic array pointer");
    }
    if (index >= array->size)
    {
        throw string("Index out of bounds in dynamic array");
    }
    return array->data[index];
}

/**
 * @brief set the value of the indicated element from the dynamic array.
 *
 * If the index is out of bounds, the function will throw an string exception.
 *
 * @tparam T the type of data in the dynamic array
 * @param array the dynamic array to set the element in
 * @param index the index of the element to change
 * @param value the value to set the element to
*/

template <typename T>
void set_in_dynamic_array(dynamic_array<T>* array, unsigned int index, const T& value)
{
    if (!array)
    {
        throw string("Null dynamic array pointer");
    }
    if (index >= array->size)
    {
        throw string("Index out of bounds in dynamic array");
    }
    array->data[index] = value;
}

#endif // DYNAMIC_ARRAY_HPP