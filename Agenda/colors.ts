import { omit } from '@/src/runtime/utils/lodash'
import { kebabCase, camelCase, upperFirst } from 'scule'

type SafelistByComponentType = {
    [key: string]: (colorsAsRegex: string) => ({ pattern: RegExp; variants?: string[]; })[];
};

type SafelistComponentAliasesMapType = {
    [key: string]: string;
};

const colorsToExclude = [
    'inherit',
    'transparent',
    'current',
    'white',
    'black',
    'slate',
    'gray',
    'zinc',
    'neutral',
    'stone',
    'cool'
]


const safelistByComponent: SafelistByComponentType = {
    alert: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-50`)
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`)
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }
        // , 
        // {
        //     pattern: new RegExp(`ring-${colorsAsRegex}-400`),
        //     variants: ['dark']
        // }, 
        // {
        //     pattern: new RegExp(`ring-${colorsAsRegex}-500`)
        // }
    ],
    avatar: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`)
    }],
    badge: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-50`)
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`)
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }
        // ,
        // {
        //     pattern: new RegExp(`ring-${colorsAsRegex}-400`),
        //     variants: ['dark']
        // }, {
        //     pattern: new RegExp(`ring-${colorsAsRegex}-500`)
        // }
    ],
    button: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-50`),
        variants: ['hover', 'disabled']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-100`),
        variants: ['hover']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark', 'dark:disabled']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`),
        variants: ['disabled', 'dark:hover']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-600`),
        variants: ['hover']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-900`),
        variants: ['dark:hover']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-950`),
        variants: ['dark', 'dark:hover', 'dark:disabled']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark', 'dark:disabled']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`),
        variants: ['dark:hover', 'disabled']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-600`),
        variants: ['hover']
    }, {
        pattern: new RegExp(`outline-(${colorsAsRegex})-400`),
        variants: ['dark:focus-visible']
    }, {
        pattern: new RegExp(`outline-(${colorsAsRegex})-500`),
        variants: ['focus-visible']
    }
        // ,
        // {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-400`),
        //     variants: ['dark:focus-visible']
        // }, {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-500`),
        //     // variants: ['focus-visible']
        // }
    ],
    input: (colorsAsRegex: string) => [{
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }
        // , {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-400`),
        //     // variants: ['dark', 'dark:focus']
        // }, {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-500`),
        //     // variants: ['focus']
        // }
    ],
    radio: (colorsAsRegex: string) => [{
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }
        // , {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-400`),
        //     // variants: ['dark:focus-visible']
        // }, {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-500`),
        //     // variants: ['focus-visible']
        // }
    ],
    checkbox: (colorsAsRegex: string) => [{
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }
        // , {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-400`),
        //     // variants: ['dark:focus-visible']
        // }, {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-500`),
        //     // variants: ['focus-visible']
        // }
    ],
    toggle: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`)
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }
        // , {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-400`),
        //     // variants: ['dark:focus-visible']
        // }, {
        //     // pattern: new RegExp(`ring-${colorsAsRegex}-500`),
        //     // variants: ['focus-visible']
        // }
    ],
    range: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`)
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }
        // , {
        //     pattern: new RegExp(`ring-${colorsAsRegex}-400`),
        //     variants: ['dark:focus-visible']
        // }, {
        //     pattern: new RegExp(`ring-${colorsAsRegex}-500`),
        //     variants: ['focus-visible']
        // }
    ],
    progress: (colorsAsRegex: string) => [{
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }],
    meter: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`)
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }],
    notification: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`)
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`text-(${colorsAsRegex})-500`)
    }],
    chip: (colorsAsRegex: string) => [{
        pattern: new RegExp(`bg-(${colorsAsRegex})-400`),
        variants: ['dark']
    }, {
        pattern: new RegExp(`bg-(${colorsAsRegex})-500`)
    }]
}

const safelistComponentAliasesMap: SafelistComponentAliasesMapType = {
    'USelect': 'UInput',
    'USelectMenu': 'UInput',
    'UTextarea': 'UInput',
    'URadioGroup': 'URadio',
    'UMeterGroup': 'UMeter'
}

const colorsAsRegex = (colors: string[]): string => colors.join('|')

export const excludeColors = (colors: object): string[] => {
    return Object.entries(omit(colors, colorsToExclude))
        .filter(([, value]) => typeof value === 'object')
        .map(([key]) => kebabCase(key))
}

export const generateSafelist = (colors: string[], globalColors: string) => {
    const baseSafelist = Object.keys(safelistByComponent).flatMap(component => {
        if (component in safelistByComponent) {
            return safelistByComponent[component](colorsAsRegex(colors))
        }
        return [];
    })
    // Ensure `red` color is safelisted for form elements so that `error` prop of `UFormGroup` always works
    const formsSafelist = ['input', 'radio', 'checkbox', 'toggle', 'range'].flatMap(component => safelistByComponent[component](colorsAsRegex(['red'])))

    return [
        ...baseSafelist,
        ...formsSafelist,
        // Ensure all global colors are safelisted for the Notification (toast.add)
        ...safelistByComponent['notification'](colorsAsRegex([globalColors])),
        // Gray safelist for Avatar & Notification
        'bg-gray-500',
        'dark:bg-gray-400',
        'text-gray-500',
        'dark:text-gray-400'
    ]
}

console.log('colors.ts está sendo carregado');

export const customSafelistExtractor = (prefix: string, content: string, colors: string[], safelistColors: string[]) => {
    const classes: string[] = []
    const regex = /<([A-Za-z][A-Za-z0-9]*(?:-[A-Za-z][A-Za-z0-9]*)*)\s+(?![^>]*:color\b)[^>]*\bcolor=["']([^"']+)["'][^>]*>/gs

    const matches = content.matchAll(regex)

    const components = Object.keys(safelistByComponent).map(component => `${prefix}${component.charAt(0).toUpperCase() + component.slice(1)}`)

    for (const match of matches) {
        const [, component, color] = match

        const camelComponent = upperFirst(camelCase(component))

        if (!colors.includes(color) || safelistColors.includes(color)) {
            continue
        }

        let name = safelistComponentAliasesMap[camelComponent] ? safelistComponentAliasesMap[camelComponent] : camelComponent

        if (!components.includes(name)) {
            continue
        }

        name = name.replace(prefix, '').toLowerCase()

        const matchClasses = safelistByComponent[name](color).flatMap(group => {
            return ['', ...(group.variants || [])].flatMap(variant => {
                const matches = group.pattern.source.match(/\(([^)]+)\)/g)

                if (!matches) {
                    return [];
                }

                return matches.map(match => {
                    const colorOptions = match.substring(1, match.length - 1).split('|')
                    return colorOptions.map(color => `${variant ? variant + ':' : ''}` + group.pattern.source.replace(match, color))
                }).flat()
            })
        })

        classes.push(...matchClasses)
    }

    return classes
}