import { useState } from 'react';

export default function useBooleanToggle(initialValue) {
    const [value, setValue] = useState(initialValue ? initialValue : false);

    const handleToggle = () => {
        setValue(!value);
    };

    const handleChange = (newValue) => {
        setValue(newValue);
    };
    return {
        value,
        onToggle: handleToggle,
        onChange: handleChange
    };
}